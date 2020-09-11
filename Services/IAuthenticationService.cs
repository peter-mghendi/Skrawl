using Skrawl.Models;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface IAuthenticationService
    {
        LoginResult Token { get; }
        // User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}