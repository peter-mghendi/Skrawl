using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value = null);
        Task Post(string uri, object value = null);
    }
}