using System.Collections.Generic;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class HostConfig
    {
        [J("Binds")] public string[] Binds { get; set; }
        [J("ContainerIDFile")] public string ContainerIdFile { get; set; }
        [J("LogConfig")] public LogConfig LogConfig { get; set; }
        [J("NetworkMode")] public string NetworkMode { get; set; }
        [J("PortBindings")] public Dictionary<string, Port[]> PortBindings { get; set; }
        [J("RestartPolicy")] public RestartPolicy RestartPolicy { get; set; }
        [J("AutoRemove")] public bool AutoRemove { get; set; }
        [J("VolumeDriver")] public string VolumeDriver { get; set; }
        [J("VolumesFrom")] public object VolumesFrom { get; set; }
        [J("CapAdd")] public object CapAdd { get; set; }
        [J("CapDrop")] public object CapDrop { get; set; }
        [J("Dns")] public object[] Dns { get; set; }
        [J("DnsOptions")] public object[] DnsOptions { get; set; }
        [J("DnsSearch")] public object[] DnsSearch { get; set; }
        [J("ExtraHosts")] public object ExtraHosts { get; set; }
        [J("GroupAdd")] public object GroupAdd { get; set; }
        [J("IpcMode")] public string IpcMode { get; set; }
        [J("Cgroup")] public string Cgroup { get; set; }
        [J("Links")] public object Links { get; set; }
        [J("OomScoreAdj")] public long OomScoreAdj { get; set; }
        [J("PidMode")] public string PidMode { get; set; }
        [J("Privileged")] public bool Privileged { get; set; }
        [J("PublishAllPorts")] public bool PublishAllPorts { get; set; }
        [J("ReadonlyRootfs")] public bool ReadonlyRootfs { get; set; }
        [J("SecurityOpt")] public string[] SecurityOpt { get; set; }
        [J("UTSMode")] public string UtsMode { get; set; }
        [J("UsernsMode")] public string UsernsMode { get; set; }
        [J("ShmSize")] public long ShmSize { get; set; }
        [J("Runtime")] public string Runtime { get; set; }
        [J("ConsoleSize")] public long[] ConsoleSize { get; set; }
        [J("Isolation")] public string Isolation { get; set; }
        [J("CpuShares")] public long CpuShares { get; set; }
        [J("Memory")] public long Memory { get; set; }
        [J("NanoCpus")] public long NanoCpus { get; set; }
        [J("CgroupParent")] public string CgroupParent { get; set; }
        [J("BlkioWeight")] public long BlkioWeight { get; set; }
        [J("BlkioWeightDevice")] public object[] BlkioWeightDevice { get; set; }
        [J("BlkioDeviceReadBps")] public object BlkioDeviceReadBps { get; set; }
        [J("BlkioDeviceWriteBps")] public object BlkioDeviceWriteBps { get; set; }
        [J("BlkioDeviceReadIOps")] public object BlkioDeviceReadIOps { get; set; }
        [J("BlkioDeviceWriteIOps")] public object BlkioDeviceWriteIOps { get; set; }
        [J("CpuPeriod")] public long CpuPeriod { get; set; }
        [J("CpuQuota")] public long CpuQuota { get; set; }
        [J("CpuRealtimePeriod")] public long CpuRealtimePeriod { get; set; }
        [J("CpuRealtimeRuntime")] public long CpuRealtimeRuntime { get; set; }
        [J("CpusetCpus")] public string CpusetCpus { get; set; }
        [J("CpusetMems")] public string CpusetMems { get; set; }
        [J("Devices")] public object[] Devices { get; set; }
        [J("DeviceCgroupRules")] public object DeviceCgroupRules { get; set; }
        [J("DiskQuota")] public long DiskQuota { get; set; }
        [J("KernelMemory")] public long KernelMemory { get; set; }
        [J("MemoryReservation")] public long MemoryReservation { get; set; }
        [J("MemorySwap")] public long MemorySwap { get; set; }
        [J("MemorySwappiness")] public object MemorySwappiness { get; set; }
        [J("OomKillDisable")] public bool OomKillDisable { get; set; }
        [J("PidsLimit")] public long PidsLimit { get; set; }
        [J("Ulimits")] public object Ulimits { get; set; }
        [J("CpuCount")] public long CpuCount { get; set; }
        [J("CpuPercent")] public long CpuPercent { get; set; }
        [J("IOMaximumIOps")] public long IoMaximumIOps { get; set; }
        [J("IOMaximumBandwidth")] public long IoMaximumBandwidth { get; set; }
    }
}
