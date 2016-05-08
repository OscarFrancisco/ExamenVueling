using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace APPWebMvc
{
    public class HttpClientSync : HttpClient, IHttpClientSync
    {
        public HttpClientSync() : base() { }
        private const string JSONEMPTY = "[]";
        public IEnumerable<T> GetListJson<T>(string jsonString)
        {
            if (JSONEMPTY != jsonString)
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            return new List<T>();
        }
    }
}