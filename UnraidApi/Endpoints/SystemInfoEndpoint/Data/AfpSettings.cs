using System;
using System.Collections.Generic;
using System.Text;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class AfpSettings
    {
        [IniParser("shareAFPEnabled")] public bool AfpEnabled { get; set; }
    }
}
