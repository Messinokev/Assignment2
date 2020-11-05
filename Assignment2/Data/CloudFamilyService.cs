using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Assignment2.Data
{
    public class CloudFamilyService : IFamilyService
    {
        private string uri = "https://localhost:44314";
        private readonly HttpClient client;

        public CloudFamilyService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Family>> GetFamilyAsync()
        {
            string message = await client.GetStringAsync(uri + "/families");

            List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
            return result;
        }

        public Task AddFamilytAsync(Family family)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFamilyAsync(Family family)
        {
            await client.DeleteAsync($"{uri}/families/{family.HouseNumber}/{family.StreetName}");
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/families/{family.HouseNumber}", content);
        }
    }
}
