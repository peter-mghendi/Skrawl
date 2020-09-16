using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string uri);
        Task PutAsync(string uri, object value = null);
        Task<T> PostAsync<T>(string uri, object value = null);
        Task PostAsync(string uri, object value = null);
        Task<T> DeleteAsync<T>(string uri);
    }
}