using System.Threading.Tasks;

namespace UnraidApi.Endpoints.ApcUpsd
{
    public interface IApcUpsdClient
    {
        Task<Models.ApcUpsd> GetUpsStatus();
    }
}
