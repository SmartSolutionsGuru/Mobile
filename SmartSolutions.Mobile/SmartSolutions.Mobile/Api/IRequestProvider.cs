using System.Threading.Tasks;

namespace SmartSolutions.Mobile.Api
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, bool aquireToken = false);

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, bool aquireToken = false);

        Task<TResult> PostAsync<TResult>(string uri, string data, bool aquireToken = false);

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, bool aquireToken = false);

        Task DeleteAsync(string uri, string token = "");
    }
}
