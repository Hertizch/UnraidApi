using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace UnraidApi.Endpoints.DiskEndpoint
{
    public interface IDiskClient
    {
        Task<List<Data.Disk>> GetDisks([Optional] bool omitParityDisk, [Optional] bool omitFlashDisk, [Optional] bool omitUnassignedDisk, [Optional] bool omitCacheDisk);
    }
}
