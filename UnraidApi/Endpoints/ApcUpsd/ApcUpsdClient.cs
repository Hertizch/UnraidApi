/*
 * Resources
 * https://linux.die.net/man/8/apcaccess
 */

using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnraidApi.Endpoints.ApcUpsd
{
    public class ApcUpsdClient : IApcUpsdClient
    {
        private UnraidApiClient _unraidApiClient;
        private string _commandResponse;

        public ApcUpsdClient(UnraidApiClient unraidApiClient)
        {
            _unraidApiClient = unraidApiClient;
        }

        public async Task<Models.ApcUpsd> GetUpsStatus()
        {
            _commandResponse = await _unraidApiClient.RunCommand("apcaccess");

            var apcUpsd = new Models.ApcUpsd();

            var properties = typeof(Models.ApcUpsd).GetProperties();
            foreach (var property in properties)
                property.SetValue(apcUpsd, GetUpsProperty(property.Name)); // polulate all properties that exists

            return apcUpsd;
        }

        private string GetUpsProperty(string upsProperty)
        {
            string output = null;

            if (!string.IsNullOrWhiteSpace(_commandResponse))
            {
                var match = Regex.Match(_commandResponse, $@"{upsProperty}\s*:\s+(.+)");
                if (match.Success)
                    output = match.Groups[1].Value;
            }

            return output;
        }
    }
}
