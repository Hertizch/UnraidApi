using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnraidApi.Endpoints.DockerEndpoint
{
    public interface IDockerClient
    {
        Task<List<Data.Docker>> GetDockers();
        Task Stop(Data.Docker docker);
        Task StopAll();
        Task Start(Data.Docker docker);
    }
}
