using System;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class State
    {
        [J("Status")] public string Status { get; set; }
        [J("Running")] public bool Running { get; set; }
        [J("Paused")] public bool Paused { get; set; }
        [J("Restarting")] public bool Restarting { get; set; }
        [J("OOMKilled")] public bool OomKilled { get; set; }
        [J("Dead")] public bool Dead { get; set; }
        [J("Pid")] public long Pid { get; set; }
        [J("ExitCode")] public long ExitCode { get; set; }
        [J("Error")] public string Error { get; set; }
        [J("StartedAt")] public DateTime StartedAt { get; set; }
        [J("FinishedAt")] public DateTime FinishedAt { get; set; }
    }
}
