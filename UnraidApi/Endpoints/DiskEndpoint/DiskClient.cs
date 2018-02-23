using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnraidApi.Enums;
using UnraidApi.Extensions;
using UnraidApi.Utilities;

namespace UnraidApi.Endpoints.DiskEndpoint
{
    public class DiskClient : IDiskClient
    {
        private UnraidApiClient _unraidApiClient;
        private List<Data.Disk> _disks;

        public DiskClient(UnraidApiClient unraidApiClient)
        {
            _unraidApiClient = unraidApiClient;
            _disks = new List<Data.Disk>();
        }

        public async Task<List<Data.Disk>> GetDisks([Optional] bool omitParityDisks, [Optional] bool omitFlashDisks, [Optional] bool omitUnassignedDisks, [Optional] bool omitCacheDisks)
        {
            // Download and read file into memory
            var remoteFileStr = await _unraidApiClient.ReadRemoteFile("/var/local/emhttp/disks.ini");
            if (remoteFileStr == null) return null;

            var ini = new IniParser(remoteFileStr);
            var iniFile = ini.ParseIniFile();
            foreach (var block in iniFile.Blocks)
            {
                // Get values to re-use
                long fsFree = ini.GetValue(block.Name, "fsFree").ToLong();
                long fsSize = ini.GetValue(block.Name, "fsSize").ToLong();
                var device = ini.GetValue(block.Name, "device");
                var type = (DiskType)Enum.Parse(typeof(DiskType), ini.GetValue(block.Name, "type"));

                // Calculate disk usage percentage
                int fsUsedPercentage = 0;
                long fsUsed = (fsSize - fsFree);
                if (fsSize != 0)
                    fsUsedPercentage = (int)(((double)fsUsed / fsSize) * 100);

                // Get power state
                var powerState = PowerState.Unknown;
                if (!string.IsNullOrEmpty(device) && type != DiskType.Flash)
                    powerState = await GetPowerState(ini.GetValue(block.Name, "device"));

                _disks.Add(new Data.Disk
                {
                    FileSystem = new Data.FileSystem
                    {
                        Status = ini.GetValue(block.Name, "fsStatus"),
                        Type = ini.GetValue(block.Name, "fsType"),
                        Color = ini.GetValue(block.Name, "fsColor"),
                        Size = fsSize,
                        SizeFree = fsFree,
                        SizeUsed = fsUsed,
                        SizeUsedPercentage = fsUsedPercentage
                    },

                    Idx = ini.GetValue(block.Name, "idx").ToInt(),
                    Name = ini.GetValue(block.Name, "name"),
                    Device = device,
                    Id = ini.GetValue(block.Name, "id"),
                    Status = (DiskStatus)Enum.Parse(typeof(DiskStatus), ini.GetValue(block.Name, "status")),
                    IsRotational = ini.GetValue(block.Name, "rotational").ToBool(),
                    Format = ini.GetValue(block.Name, "format"),
                    Temp = ini.GetValue(block.Name, "temp").ToInt(),
                    NumReads = ini.GetValue(block.Name, "numReads").ToLong(),
                    NumWrites = ini.GetValue(block.Name, "numWrites").ToLong(),
                    NumErrors = ini.GetValue(block.Name, "numErrors").ToLong(),
                    Type = type,
                    Color = ini.GetValue(block.Name, "color"),
                    LuksState = ini.GetValue(block.Name, "luksState").ToInt(),
                    Comment = ini.GetValue(block.Name, "comment"),
                    IsExportable = ini.GetValue(block.Name, "exportable").ToBool(),
                    SpindownDelay = ini.GetValue(block.Name, "spindownDelay").ToInt(),
                    SpinupGroup = ini.GetValue(block.Name, "spinupGroup"),
                    Uuid = ini.GetValue(block.Name, "uuid"),
                    PowerState = powerState
                });
            }

            // Remove drive objects based on constructor parameters
            if (omitParityDisks)
                _disks.RemoveAll(d => d.Type == DiskType.Parity);

            if (omitFlashDisks)
                _disks.RemoveAll(d => d.Type == DiskType.Flash);

            if (omitCacheDisks)
                _disks.RemoveAll(d => d.Type == DiskType.Cache);

            if (omitUnassignedDisks)
                _disks.RemoveAll(d => d.Status == DiskStatus.DISK_NP || d.Status == DiskStatus.DISK_NP_DSBL);

            return _disks;
        }

        private async Task<PowerState> GetPowerState(string device)
        {
            if (string.IsNullOrEmpty(device)) return PowerState.Unknown;

            // Get smartctl command
            var commandStr = await _unraidApiClient.RunCommand($"smartctl --nocheck standby /dev/{device}");
            if (commandStr != null)
            {
                // Find power state
                var regex = new Regex(@"Device is in (.+) mode");

                // If no matches
                if (!regex.IsMatch(commandStr))
                    Debug.WriteLine($"[DEBUG] [DiskClient.IsIdle] Got no matches from string 'commandStr'");

                // Loop all matches and interpret results
                foreach (Match match in regex.Matches(commandStr))
                {
                    switch (match.Groups[1].Value)
                    {
                        case "STANDBY":
                            return PowerState.Standby;
                        case "IDLE_A":
                            return PowerState.Idle;
                        case "ACTIVE or IDLE":
                            return PowerState.ActiveOrIdle;
                    }
                }
            }

            return PowerState.Unknown;
        }
    }
}
