using Skrawl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}