using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Data
{
    public class CloudAdultService : IAdultService
    {
        private string uri = "https://localhost:44314";
        private readonly HttpClient client;

        public CloudAdultService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultAsync(string name, int age)
        {
            string message = "";
            if (name == null)
            {
                if (age < 0)
                {
                    message = await client.GetStringAsync(uri + "/adults");
                }
                else
                {
                    message = await client.GetStringAsync(uri + "/adults?age=" + age);
                }
            }
            else
            {
                message = await client.GetStringAsync(uri + "/adults?age=" + age + "&name=" + name);
            }
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {

            string message = await client.GetStringAsync(uri + "/adults?id=" + id);

            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            Adult result1 = new Adult();
            for (int i = 0; i < 1; i++)
            {
                result1 = result.First();
            }
            return result1;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/adults", content);
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            await client.DeleteAsync($"{uri}/adults/{adultId}");
        }

        public async Task UpdateAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/adults/{adult.Id}", content);
        }
    }
}
