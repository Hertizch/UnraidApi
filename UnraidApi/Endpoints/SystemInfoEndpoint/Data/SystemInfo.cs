using System;
using static UnraidApi.Utilities.IniParser;

namespace UnraidApi.Endpoints.SystemInfoEndpoint.Data
{
    /// <summary>
    /// Todo:
    /// Give properties friendly names
    /// Fix name violations
    /// </summary>
    public class SystemInfo
    {
        public Registration Registration { get; set; }
        public Identification Identification { get; set; }
        public SslCertificateSettings SslCertificateSettings { get; set; }
        public DateAndTime DateAndTime { get; set; }
        public SmbSettings SmbSettings { get; set; }
        public NfsSettings NfsSettings { get; set; }
        public AfpSettings AfpSettings { get; set; }

        [IniParser("MAX_ARRAYSZ")] public int MAX_ARRAYSZ { get; set; }
        [IniParser("MAX_CACHESZ")] public int MAX_CACHESZ { get; set; }
        [IniParser("SECURITY")] public string SECURITY { get; set; }
        [IniParser("DOMAIN")] public string DOMAIN { get; set; }
        [IniParser("DOMAIN_SHORT")] public string DOMAIN_SHORT { get; set; }
        [IniParser("DOMAIN_LOGIN")] public string DOMAIN_LOGIN { get; set; }
        [IniParser("SYS_ARRAY_SLOTS")] public int SYS_ARRAY_SLOTS { get; set; }
        [IniParser("SYS_CACHE_SLOTS")] public int SYS_CACHE_SLOTS { get; set; }
        [IniParser("SYS_FLASH_SLOTS")] public int SYS_FLASH_SLOTS { get; set; }
        [IniParser("startArray")] public bool StartArray { get; set; }
        [IniParser("spindownDelay")] public int SpindownDelay { get; set; }
        [IniParser("queueDepth")] public string QueueDepth { get; set; }
        [IniParser("spinupGroups")] public bool SpinupGroups { get; set; }
        [IniParser("defaultFormat")] public int DefaultFormat { get; set; }
        [IniParser("defaultFsType")] public string DefaultFsType { get; set; }
        [IniParser("shutdownTimeout")] public int ShutdownTimeout { get; set; }
        [IniParser("luksKeyfile")] public string LuksKeyfile { get; set; }
        [IniParser("poll_attributes")] public int Poll_attributes { get; set; }
        [IniParser("poll_attributes_default")] public int Poll_attributes_default { get; set; }
        [IniParser("poll_attributes_status")] public string Poll_attributes_status { get; set; }
        [IniParser("nr_requests")] public int Nr_requests { get; set; }
        [IniParser("nr_requests_default")] public int Nr_requests_default { get; set; }
        [IniParser("nr_requests_status")] public string Nr_requests_status { get; set; }
        [IniParser("md_num_stripes")] public int Md_num_stripes { get; set; }
        [IniParser("md_num_stripes_default")] public int Md_num_stripes_default { get; set; }
        [IniParser("md_num_stripes_status")] public string Md_num_stripes_status { get; set; }
        [IniParser("md_sync_window")] public int Md_sync_window { get; set; }
        [IniParser("md_sync_window_default")] public int Md_sync_window_default { get; set; }
        [IniParser("md_sync_window_status")] public string Md_sync_window_status { get; set; }
        [IniParser("md_sync_thresh")] public int Md_sync_thresh { get; set; }
        [IniParser("md_sync_thresh_default")] public int Md_sync_thresh_default { get; set; }
        [IniParser("md_sync_thresh_status")] public string Md_sync_thresh_status { get; set; }
        [IniParser("md_write_method")] public string Md_write_method { get; set; }
        [IniParser("md_write_method_default")] public string Md_write_method_default { get; set; }
        [IniParser("md_write_method_status")] public string Md_write_method_status { get; set; }
        [IniParser("shareDisk")] public bool ShareDisk { get; set; }
        [IniParser("shareUser")] public string ShareUser { get; set; }
        [IniParser("shareUserInclude")] public string ShareUserInclude { get; set; }
        [IniParser("shareUserExclude")] public string ShareUserExclude { get; set; }
        [IniParser("shareInitialOwner")] public string ShareInitialOwner { get; set; }
        [IniParser("shareInitialGroup")] public string ShareInitialGroup { get; set; }
        [IniParser("shareCacheEnabled")] public bool ShareCacheEnabled { get; set; }
        [IniParser("shareCacheFloor")] public string ShareCacheFloor { get; set; }
        [IniParser("shareMoverSchedule")] public string ShareMoverSchedule { get; set; }
        [IniParser("shareMoverLogging")] public bool ShareMoverLogging { get; set; }
        [IniParser("fuse_directio")] public string Fuse_directio { get; set; }
        [IniParser("fuse_directio_default")] public string Fuse_directio_default { get; set; }
        [IniParser("fuse_directio_status")] public string Fuse_directio_status { get; set; }
        [IniParser("shareAvahiEnabled")] public bool ShareAvahiEnabled { get; set; }
        [IniParser("shareAvahiSMBName")] public string ShareAvahiSMBName { get; set; }
        [IniParser("shareAvahiSMBModel")] public string ShareAvahiSMBModel { get; set; }
        [IniParser("shareAvahiAFPName")] public string ShareAvahiAFPName { get; set; }
        [IniParser("shareAvahiAFPModel")] public string ShareAvahiAFPModel { get; set; }
        [IniParser("safeMode")] public bool SafeMode { get; set; }
        [IniParser("startMode")] public string StartMode { get; set; }
        [IniParser("configValid")] public bool ConfigValid { get; set; }
        [IniParser("joinStatus")] public string JoinStatus { get; set; }
        [IniParser("deviceCount")] public int DeviceCount { get; set; }
        [IniParser("flashGUID")] public string FlashGUID { get; set; }
        [IniParser("flashProduct")] public string FlashProduct { get; set; }
        [IniParser("flashVendor")] public string FlashVendor { get; set; }
        [IniParser("sbName")] public string SbName { get; set; }
        [IniParser("sbVersion")] public string SbVersion { get; set; }
        [IniParser("sbUpdated")] public DateTime SbUpdated { get; set; }
        [IniParser("sbEvents")] public int SbEvents { get; set; }
        [IniParser("sbState")] public int SbState { get; set; }
        [IniParser("sbClean")] public bool SbClean { get; set; }
        [IniParser("sbSynced")] public DateTime SbSynced { get; set; }
        [IniParser("sbSyncErrs")] public int SbSyncErrs { get; set; }
        [IniParser("sbSynced2")] public DateTime SbSynced2 { get; set; }
        [IniParser("sbSyncExit")] public int SbSyncExit { get; set; }
        [IniParser("sbNumDisks")] public int SbNumDisks { get; set; }
        [IniParser("mdColor")] public string MdColor { get; set; }
        [IniParser("mdNumDisks")] public int MdNumDisks { get; set; }
        [IniParser("mdNumDisabled")] public int MdNumDisabled { get; set; }
        [IniParser("mdNumInvalid")] public int MdNumInvalid { get; set; }
        [IniParser("mdNumMissing")] public int MdNumMissing { get; set; }
        [IniParser("mdNumNew")] public int MdNumNew { get; set; }
        [IniParser("mdNumErased")] public int MdNumErased { get; set; }
        [IniParser("mdResync")] public int MdResync { get; set; }
        [IniParser("mdResyncCorr")] public int MdResyncCorr { get; set; }
        [IniParser("mdResyncPos")] public long MdResyncPos { get; set; }
        [IniParser("mdResyncDb")] public long MdResyncDb { get; set; }
        [IniParser("mdResyncDt")] public long MdResyncDt { get; set; }
        [IniParser("mdResyncAction")] public string MdResyncAction { get; set; }
        [IniParser("mdResyncSize")] public long MdResyncSize { get; set; }
        [IniParser("mdState")] public string MdState { get; set; }
        [IniParser("mdVersion")] public string MdVersion { get; set; }
        [IniParser("cacheNumDevices")] public int CacheNumDevices { get; set; }
        [IniParser("cacheSbNumDisks")] public int CacheSbNumDisks { get; set; }
        [IniParser("fsState")] public string FsState { get; set; }
        [IniParser("fsProgress")] public int FsProgress { get; set; }
        [IniParser("fsCopyPrcnt")] public int FsCopyPrcnt { get; set; }
        [IniParser("fsNumMounted")] public int FsNumMounted { get; set; }
        [IniParser("fsNumUnmountable")] public int FsNumUnmountable { get; set; }
        [IniParser("fsUnmountableMask")] public int FsUnmountableMask { get; set; }
        [IniParser("shareCount")] public int ShareCount { get; set; }
        [IniParser("shareSMBCount")] public int ShareSMBCount { get; set; }
        [IniParser("shareNFSCount")] public int ShareNFSCount { get; set; }
        [IniParser("shareAFPCount")] public int ShareAFPCount { get; set; }
        [IniParser("shareMoverActive")] public bool ShareMoverActive { get; set; }
        [IniParser("csrf_token")] public string Csrf_token { get; set; }
    }
}
