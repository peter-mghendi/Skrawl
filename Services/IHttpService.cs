using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task Put(string uri, object value = null);
        Task<T> Post<T>(string uri, object value = null);
        Task Post(string uri, object value = null);
    }
}