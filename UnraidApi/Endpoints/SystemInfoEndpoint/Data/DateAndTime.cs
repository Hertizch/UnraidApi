using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    public class DateAndTime
    {
        [IniParser("timeZone")] public string TimeZone { get; set; }
        [IniParser("USE_NTP")] public bool UseNtp { get; set; }
        [IniParser("NTP_SERVER1")] public string NtpServer1 { get; set; }
        [IniParser("NTP_SERVER2")] public string NtpServer2 { get; set; }
        [IniParser("NTP_SERVER3")] public string NtpServer3 { get; set; }
    }
}
