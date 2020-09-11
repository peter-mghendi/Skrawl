using Skrawl.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        // public User User { get; private set; }
        public LoginResult Token { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            // User = await _localStorageService.GetItem<User>("user");
            Token = await _localStorageService.GetItem<LoginResult>("token");
        }

        public async Task Login(string email, string password)
        {
            // User = await _httpService.Post<User>("/users/authenticate", new { username, password });
            // await _localStorageService.SetItem("user", User);
            
            Token = await _httpService.Post<LoginResult>("/users/authenticate", new { email, password });
            await _localStorageService.SetItem<LoginResult>("token", Token);
        }

        public async Task Logout()
        {
            Token = null;
            await _localStorageService.RemoveItem("token");    

            // User = null;
            // await _localStorageService.RemoveItem("user");

            _navigationManager.NavigateTo("login");
        }
    }
}