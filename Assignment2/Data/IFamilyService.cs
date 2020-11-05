using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamilyAsync();
        Task AddFamilytAsync(Family family);
        Task RemoveFamilyAsync(Family family);
        Task UpdateFamilyAsync(Family family);
    }
}
