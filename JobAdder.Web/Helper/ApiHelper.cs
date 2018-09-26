using System;
using System.Collections.Generic;
using System.Net.Http;
using JobAdder.Web.Configurations;

namespace JobAdder.Web.Helper
{

    public interface IApiHelper
    {
        HttpResponseMessage ExecuteApiCallAsync(string url,IDictionary<string, string> headers = null);
   }

    public class ApiHelper : EndPointResolver, IApiHelper
    {
        private readonly HttpClient _client;
        public ApiHelper(HttpClient client = null) : base("Api.JobAdder")
        {
            _client = client?? new HttpClient();
        }
        public HttpResponseMessage ExecuteApiCallAsync(string url, IDictionary<string, string> headers= null)
        {

            var response = _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri($"{BaseAddress}{ url}"))).Result;


            if (response.IsSuccessStatusCode)
            {
               return response;
            }

            return null;
        }
   }
}