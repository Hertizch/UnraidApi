using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class NfsSettings
    {
        [IniParser("shareNFSEnabled")] public bool NfsEnabled { get; set; }
        [IniParser("fuse_remember")] public int Tunable { get; set; }
        [IniParser("fuse_remember_default")] public int TunableDefault { get; set; }
        [IniParser("fuse_remember_status")] public string TunableStatus { get; set; }
    }
}
