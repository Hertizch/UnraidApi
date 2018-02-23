using UnraidApi.Enums;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.DiskEndpoint.Data
{
    /// <summary>
    /// Todo:
    /// Rename to friendly properties
    /// Add used size
    /// Add used size percentage
    /// </summary>
    public class Disk
    {
        public FileSystem FileSystem { get; set; }
        [IniParser("idx")] public int Idx { get; set; }
        [IniParser("name")] public string Name { get; set; }
        [IniParser("device")] public string Device { get; set; }
        [IniParser("id")] public string Id { get; set; }
        [IniParser("status")] public DiskStatus Status { get; set; }
        [IniParser("rotational")] public bool IsRotational { get; set; }
        [IniParser("format")] public string Format { get; set; }
        [IniParser("temp")] public int Temp { get; set; }
        [IniParser("numReads")] public long NumReads { get; set; }
        [IniParser("numWrites")] public long NumWrites { get; set; }
        [IniParser("numErrors")] public long NumErrors { get; set; }
        [IniParser("type")] public DiskType Type { get; set; }
        [IniParser("color")] public string Color { get; set; }
        [IniParser("luksState")] public int LuksState { get; set; }
        [IniParser("comment")] public string Comment { get; set; }
        [IniParser("exportable")] public bool IsExportable { get; set; }
        [IniParser("spindownDelay")] public int SpindownDelay { get; set; }
        [IniParser("spinupGroup")] public string SpinupGroup { get; set; }
        [IniParser("uuid")] public string Uuid { get; set; }
        [IniParser("powerState")] public PowerState PowerState { get; set; }
    }
}
