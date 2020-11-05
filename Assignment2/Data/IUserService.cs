using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Data
{
   public interface IUserService
    {
        Task<User> GetUserAsync(string userName, string password);
    }
}
