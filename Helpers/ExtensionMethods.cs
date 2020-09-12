using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;

namespace Skrawl.Helpers
{
    public static class ExtensionMethods
    {
        public static NameValueCollection QueryString(this NavigationManager navigationManager)
        {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key];
        }
        
        public static void CheckResponseSuccess(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var up = new HttpRequestException();
                up.Data.Add("StatusCode", response.StatusCode);
                throw up;
            }
        }
    }
}