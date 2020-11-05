using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAdultAsync(string name, int age);
        Task<Adult> GetAdultByIdAsync(int id);
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task UpdateAdultAsync(Adult adult);
    }
}
