using System.Threading.Tasks;
using UnraidApi.Enums;
using UnraidApi.Extensions;
using UnraidApi.Utilities;

namespace UnraidApi.Endpoints.SystemInfoEndpoint
{
    public class SystemInfoClient : ISystemInfoClient
    {
        private UnraidApiClient _unraidApiClient;
        private Data.SystemInfo _systemInfo;

        public SystemInfoClient(UnraidApiClient unraidApiClient)
        {
            _unraidApiClient = unraidApiClient;
        }

        public async Task<Data.SystemInfo> GetSystemInfo()
        {
            // Download and read file into memory
            var remoteFileStr = await _unraidApiClient.ReadRemoteFile("/var/local/emhttp/var.ini");
            if (remoteFileStr == null) return null;

            var ini = new IniParser(remoteFileStr);
            var iniFile = ini.ParseIniFile();
            foreach (var block in iniFile.Blocks)
            {
                // Parse regTy to LicenceKey
                LicenseKey licenceKey = 0;
                var regTy = ini.GetValue(block.Name, "regTy");
                if (regTy != null)
                {
                    switch (regTy)
                    {
                        case "Trial":
                            licenceKey = LicenseKey.Trial;
                            break;
                        case "Basic":
                            licenceKey = LicenseKey.Basic;
                            break;
                        case "Plus":
                            licenceKey = LicenseKey.Plus;
                            break;
                        case "Pro":
                            licenceKey = LicenseKey.Pro;
                            break;
                    }
                }

                _systemInfo = new Data.SystemInfo
                {
                    Registration = new Data.Registration
                    {
                        RegCheck = ini.GetValue(block.Name, "regCheck"),
                        RegFILE = ini.GetValue(block.Name, "regFILE"),
                        RegGUID = ini.GetValue(block.Name, "regGUID"),
                        RegTo = ini.GetValue(block.Name, "regTo"),
                        RegTm = ini.GetValue(block.Name, "regTm").ToLong().FromUnixTime(),
                        RegTm2 = ini.GetValue(block.Name, "regTm2").ToLong().FromUnixTime(),
                        RegGen = ini.GetValue(block.Name, "regGen").ToInt(),
                        LicenseKey = licenceKey
                    },

                    Identification = new Data.Identification
                    {
                        ServerName = ini.GetValue(block.Name, "NAME"),
                        Description = ini.GetValue(block.Name, "COMMENT"),
                        Model = ini.GetValue(block.Name, "SYS_MODEL"),
                        Version = ini.GetValue(block.Name, "version"),
                    },

                    SslCertificateSettings = new Data.SslCertificateSettings
                    {
                        UseSsl = ini.GetValue(block.Name, "USE_SSL"),
                        HttpPort = ini.GetValue(block.Name, "PORT").ToInt(),
                        HttpsPort = ini.GetValue(block.Name, "PORTSSL").ToInt(),
                        LocalTld = ini.GetValue(block.Name, "LOCAL_TLD"),
                    },

                    DateAndTime = new Data.DateAndTime
                    {
                        TimeZone = ini.GetValue(block.Name, "timeZone"),
                        UseNtp = ini.GetValue(block.Name, "USE_NTP").ToBool(),
                        NtpServer1 = ini.GetValue(block.Name, "NTP_SERVER1"),
                        NtpServer2 = ini.GetValue(block.Name, "NTP_SERVER2"),
                        NtpServer3 = ini.GetValue(block.Name, "NTP_SERVER3"),
                    },

                    SmbSettings = new Data.SmbSettings
                    {
                        Workgroup = ini.GetValue(block.Name, "WORKGROUP"),
                        HideDotFiles = ini.GetValue(block.Name, "hideDotFiles").ToBool(),
                        LocalMasterBrowser = ini.GetValue(block.Name, "localMaster").ToBool(),
                        SmbEnabled = ini.GetValue(block.Name, "shareSMBEnabled").ToBool(),
                    },

                    NfsSettings = new Data.NfsSettings
                    {
                        NfsEnabled = ini.GetValue(block.Name, "shareNFSEnabled").ToBool(),
                        Tunable = ini.GetValue(block.Name, "fuse_remember").ToInt(),
                        TunableDefault = ini.GetValue(block.Name, "fuse_remember_default").ToInt(),
                        TunableStatus = ini.GetValue(block.Name, "fuse_remember_status"),
                    },

                    AfpSettings = new Data.AfpSettings
                    {
                        AfpEnabled = ini.GetValue(block.Name, "shareAFPEnabled").ToBool(),
                    },

                    MAX_ARRAYSZ = ini.GetValue(block.Name, "MAX_ARRAYSZ").ToInt(),
                    MAX_CACHESZ = ini.GetValue(block.Name, "MAX_CACHESZ").ToInt(),
                    SECURITY = ini.GetValue(block.Name, "SECURITY"),
                    DOMAIN = ini.GetValue(block.Name, "DOMAIN"),
                    DOMAIN_SHORT = ini.GetValue(block.Name, "DOMAIN_SHORT"),
                    DOMAIN_LOGIN = ini.GetValue(block.Name, "DOMAIN_LOGIN"),
                    SYS_ARRAY_SLOTS = ini.GetValue(block.Name, "SYS_ARRAY_SLOTS").ToInt(),
                    SYS_CACHE_SLOTS = ini.GetValue(block.Name, "SYS_CACHE_SLOTS").ToInt(),
                    SYS_FLASH_SLOTS = ini.GetValue(block.Name, "SYS_FLASH_SLOTS").ToInt(),
                    StartArray = ini.GetValue(block.Name, "startArray").ToBool(),
                    SpindownDelay = ini.GetValue(block.Name, "spindownDelay").ToInt(),
                    QueueDepth = ini.GetValue(block.Name, "queueDepth"),
                    SpinupGroups = ini.GetValue(block.Name, "spinupGroups").ToBool(),
                    DefaultFormat = ini.GetValue(block.Name, "defaultFormat").ToInt(),
                    DefaultFsType = ini.GetValue(block.Name, "defaultFsType"),
                    ShutdownTimeout = ini.GetValue(block.Name, "shutdownTimeout").ToInt(),
                    LuksKeyfile = ini.GetValue(block.Name, "luksKeyfile"),
                    Poll_attributes = ini.GetValue(block.Name, "poll_attributes").ToInt(),
                    Poll_attributes_default = ini.GetValue(block.Name, "poll_attributes_default").ToInt(),
                    Poll_attributes_status = ini.GetValue(block.Name, "poll_attributes_status"),
                    Nr_requests = ini.GetValue(block.Name, "nr_requests").ToInt(),
                    Nr_requests_default = ini.GetValue(block.Name, "nr_requests_default").ToInt(),
                    Nr_requests_status = ini.GetValue(block.Name, "nr_requests_status"),
                    Md_num_stripes = ini.GetValue(block.Name, "md_num_stripes").ToInt(),
                    Md_num_stripes_default = ini.GetValue(block.Name, "md_num_stripes_default").ToInt(),
                    Md_num_stripes_status = ini.GetValue(block.Name, "md_num_stripes_status"),
                    Md_sync_window = ini.GetValue(block.Name, "md_sync_window").ToInt(),
                    Md_sync_window_default = ini.GetValue(block.Name, "md_sync_window_default").ToInt(),
                    Md_sync_window_status = ini.GetValue(block.Name, "md_sync_window_status"),
                    Md_sync_thresh = ini.GetValue(block.Name, "md_sync_thresh").ToInt(),
                    Md_sync_thresh_default = ini.GetValue(block.Name, "md_sync_thresh_default").ToInt(),
                    Md_sync_thresh_status = ini.GetValue(block.Name, "md_sync_thresh_status"),
                    Md_write_method = ini.GetValue(block.Name, "md_write_method"),
                    Md_write_method_default = ini.GetValue(block.Name, "md_write_method_default"),
                    Md_write_method_status = ini.GetValue(block.Name, "md_write_method_status"),
                    ShareDisk = ini.GetValue(block.Name, "shareDisk").ToBool(),
                    ShareUser = ini.GetValue(block.Name, "shareUser"),
                    ShareUserInclude = ini.GetValue(block.Name, "shareUserInclude"),
                    ShareUserExclude = ini.GetValue(block.Name, "shareUserExclude"),
                    ShareInitialOwner = ini.GetValue(block.Name, "shareInitialOwner"),
                    ShareInitialGroup = ini.GetValue(block.Name, "shareInitialGroup"),
                    ShareCacheEnabled = ini.GetValue(block.Name, "shareCacheEnabled").ToBool(),
                    ShareCacheFloor = ini.GetValue(block.Name, "shareCacheFloor"),
                    ShareMoverSchedule = ini.GetValue(block.Name, "shareMoverSchedule"),
                    ShareMoverLogging = ini.GetValue(block.Name, "shareMoverLogging").ToBool(),
                    Fuse_directio = ini.GetValue(block.Name, "fuse_directio"),
                    Fuse_directio_default = ini.GetValue(block.Name, "fuse_directio_default"),
                    Fuse_directio_status = ini.GetValue(block.Name, "fuse_directio_status"),
                    ShareAvahiEnabled = ini.GetValue(block.Name, "shareAvahiEnabled").ToBool(),
                    ShareAvahiSMBName = ini.GetValue(block.Name, "shareAvahiSMBName"),
                    ShareAvahiSMBModel = ini.GetValue(block.Name, "shareAvahiSMBModel"),
                    ShareAvahiAFPName = ini.GetValue(block.Name, "shareAvahiAFPName"),
                    ShareAvahiAFPModel = ini.GetValue(block.Name, "shareAvahiAFPModel"),
                    SafeMode = ini.GetValue(block.Name, "safeMode").ToBool(),
                    StartMode = ini.GetValue(block.Name, "startMode"),
                    ConfigValid = ini.GetValue(block.Name, "configValid").ToBool(),
                    JoinStatus = ini.GetValue(block.Name, "joinStatus"),
                    DeviceCount = ini.GetValue(block.Name, "deviceCount").ToInt(),
                    FlashGUID = ini.GetValue(block.Name, "flashGUID"),
                    FlashProduct = ini.GetValue(block.Name, "flashProduct"),
                    FlashVendor = ini.GetValue(block.Name, "flashVendor"),
                    SbName = ini.GetValue(block.Name, "sbName"),
                    SbVersion = ini.GetValue(block.Name, "sbVersion"),
                    SbUpdated = ini.GetValue(block.Name, "sbUpdated").ToLong().FromUnixTime(),
                    SbEvents = ini.GetValue(block.Name, "sbEvents").ToInt(),
                    SbState = ini.GetValue(block.Name, "sbState").ToInt(),
                    SbClean = ini.GetValue(block.Name, "sbClean").ToBool(),
                    SbSynced = ini.GetValue(block.Name, "sbSynced").ToLong().FromUnixTime(),
                    SbSyncErrs = ini.GetValue(block.Name, "sbSyncErrs").ToInt(),
                    SbSynced2 = ini.GetValue(block.Name, "sbSynced2").ToLong().FromUnixTime(),
                    SbSyncExit = ini.GetValue(block.Name, "sbSyncExit").ToInt(),
                    SbNumDisks = ini.GetValue(block.Name, "sbNumDisks").ToInt(),
                    MdColor = ini.GetValue(block.Name, "mdColor"),
                    MdNumDisks = ini.GetValue(block.Name, "mdNumDisks").ToInt(),
                    MdNumDisabled = ini.GetValue(block.Name, "mdNumDisabled").ToInt(),
                    MdNumInvalid = ini.GetValue(block.Name, "mdNumInvalid").ToInt(),
                    MdNumMissing = ini.GetValue(block.Name, "mdNumMissing").ToInt(),
                    MdNumNew = ini.GetValue(block.Name, "mdNumNew").ToInt(),
                    MdNumErased = ini.GetValue(block.Name, "mdNumErased").ToInt(),
                    MdResync = ini.GetValue(block.Name, "mdResync").ToInt(),
                    MdResyncCorr = ini.GetValue(block.Name, "mdResyncCorr").ToInt(),
                    MdResyncPos = ini.GetValue(block.Name, "mdResyncPos").ToLong(),
                    MdResyncDb = ini.GetValue(block.Name, "mdResyncDb").ToLong(),
                    MdResyncDt = ini.GetValue(block.Name, "mdResyncDt").ToLong(),
                    MdResyncAction = ini.GetValue(block.Name, "mdResyncAction"),
                    MdResyncSize = ini.GetValue(block.Name, "mdResyncSize").ToLong(),
                    MdState = ini.GetValue(block.Name, "mdState"),
                    MdVersion = ini.GetValue(block.Name, "mdVersion"),
                    CacheNumDevices = ini.GetValue(block.Name, "cacheNumDevices").ToInt(),
                    CacheSbNumDisks = ini.GetValue(block.Name, "cacheSbNumDisks").ToInt(),
                    FsState = ini.GetValue(block.Name, "fsState"),
                    FsProgress = ini.GetValue(block.Name, "fsProgress").ToInt(),
                    FsCopyPrcnt = ini.GetValue(block.Name, "fsCopyPrcnt").ToInt(),
                    FsNumMounted = ini.GetValue(block.Name, "fsNumMounted").ToInt(),
                    FsNumUnmountable = ini.GetValue(block.Name, "fsNumUnmountable").ToInt(),
                    FsUnmountableMask = ini.GetValue(block.Name, "fsUnmountableMask").ToInt(),
                    ShareCount = ini.GetValue(block.Name, "shareCount").ToInt(),
                    ShareSMBCount = ini.GetValue(block.Name, "shareSMBCount").ToInt(),
                    ShareNFSCount = ini.GetValue(block.Name, "shareNFSCount").ToInt(),
                    ShareAFPCount = ini.GetValue(block.Name, "shareAFPCount").ToInt(),
                    ShareMoverActive = ini.GetValue(block.Name, "shareMoverActive").ToBool(),
                    Csrf_token = ini.GetValue(block.Name, "csrf_token")
                };
            }

            return _systemInfo;
        }
    }
}
