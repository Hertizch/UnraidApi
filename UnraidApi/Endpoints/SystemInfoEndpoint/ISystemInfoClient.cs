using System.Threading.Tasks;

namespace UnraidApi.Endpoints.SystemInfoEndpoint
{
    public interface ISystemInfoClient
    {
        Task<Data.SystemInfo> GetSystemInfo();
    }
}
