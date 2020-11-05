using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment2.Models;


namespace Assignment2.Data
{
    public class CloudUserService : IUserService
    {
        private string uri = "https://localhost:44314";
        private readonly HttpClient client;

        public CloudUserService()
        {
            client = new HttpClient();
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            string message = await client.GetStringAsync(uri + "/users?userName=" + userName);
            

            User result = JsonSerializer.Deserialize<User>(message);

            if (!result.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return result;
        }
    }
}