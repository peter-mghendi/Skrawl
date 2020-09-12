using System;
using System.Net;
using System.Net.Http;
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

        public LoginResult Token { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            Token = await _localStorageService.GetItem<LoginResult>("token");
        }

        public async Task Login(string email, string password)
        {
            try
            {
                Token = await _httpService.Post<LoginResult>("api/users/tokens", new { email, password });
                await _localStorageService.SetItem<LoginResult>("token", Token);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Data["StatusCode"] switch
                {
                    HttpStatusCode.BadRequest => "Invalid login credentials.",
                    HttpStatusCode.NotFound => "Invalid login credentials.",
                    _ => "Something went wrong, please try again later."
                });
            }
        }

        public async Task Logout()
        {
            try
            {
                await _httpService.Post("api/users/tokens/invalidate");
            }
            catch (HttpRequestException ex) when (ex.Data.Contains("StatusCode"))
            {
                throw new Exception(ex.Data["StatusCode"] switch
                {
                    _ => "Something went wrong, please try again later."
                });
            }
            
            Token = null;
            await _localStorageService.RemoveItem("token");
            _navigationManager.NavigateTo("login");
        }
    }
}