using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class SslCertificateSettings
    {
        [IniParser("USE_SSL")] public string UseSsl { get; set; }
        [IniParser("PORT")] public int HttpPort { get; set; }
        [IniParser("PORTSSL")] public int HttpsPort { get; set; }
        [IniParser("LOCAL_TLD")] public string LocalTld { get; set; }
    }
}
