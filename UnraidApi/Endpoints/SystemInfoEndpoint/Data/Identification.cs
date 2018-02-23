using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class Identification
    {
        [IniParser("NAME")] public string ServerName { get; set; }
        [IniParser("COMMENT")] public string Description { get; set; }
        [IniParser("SYS_MODEL")] public string Model { get; set; }
        [IniParser("version")] public string Version { get; set; }
    }
}
