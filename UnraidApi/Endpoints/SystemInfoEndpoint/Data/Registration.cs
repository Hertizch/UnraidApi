using System;
using UnraidApi.Enums;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class Registration
    {
        [IniParser("regCheck")] public string RegCheck { get; set; }
        [IniParser("regFILE")] public string RegFILE { get; set; }
        [IniParser("regGUID")] public string RegGUID { get; set; }
        [IniParser("regTy")] public LicenseKey LicenseKey { get; set; }
        [IniParser("regTo")] public string RegTo { get; set; }
        [IniParser("regTm")] public DateTime RegTm { get; set; }
        [IniParser("regTm2")] public DateTime RegTm2 { get; set; }
        [IniParser("regGen")] public int RegGen { get; set; }
    }
}
