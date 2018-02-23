using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class SmbSettings
    {
        [IniParser("shareSMBEnabled")] public bool SmbEnabled { get; set; }
        [IniParser("hideDotFiles")] public bool HideDotFiles { get; set; }
        [IniParser("WORKGROUP")] public string Workgroup { get; set; }
        [IniParser("localMaster")] public bool LocalMasterBrowser { get; set; }
    }
}
