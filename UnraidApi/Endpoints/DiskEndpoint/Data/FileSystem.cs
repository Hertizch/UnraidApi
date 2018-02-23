using System;
using System.Collections.Generic;
using System.Text;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.DiskEndpoint.Data
{
    public class FileSystem
    {
        [IniParser("fsType")] public string Type { get; set; }
        [IniParser("fsColor")] public string Color { get; set; }
        [IniParser("fsSize")] public long Size { get; set; }
        [IniParser("fsFree")] public long SizeFree { get; set; }
        [IniParser("fsUsed")] public long SizeUsed { get; set; }
        [IniParser("fsUsedPercentage")] public int SizeUsedPercentage { get; set; }
        [IniParser("fsStatus")] public string Status { get; set; }
    }
}
