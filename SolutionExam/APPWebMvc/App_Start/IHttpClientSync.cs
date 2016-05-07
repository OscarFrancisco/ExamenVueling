using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APPWebMvc
{
    public interface IHttpClientSync : IDisposable
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        IEnumerable<T> GetListArticlesJson<T>(string jsonString);
    }
}