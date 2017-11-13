using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Zenefits.Assignment.Utilities;

namespace Zenefits.Assignment.Service.WebUtilities
{
    public class ServiceProxy : IServiceProxy
    {

        public HttpClient ServiceInit(TimeSpan timeout, bool automaticDecompression, string url)
            {
                HttpClient client;
                if (automaticDecompression)
                {
                    client = new HttpClient(new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    });
                }
                else
                {
                    client = new HttpClient();
                }
                client.DefaultRequestHeaders.Add(AssignmentConstants.AUTH_HEADER, AssignmentConstants.AUTH_SCHEME + " " + AssignmentConstants.ACCESS_KEY);
                client.BaseAddress = new Uri(url);
                client.Timeout = timeout != default(TimeSpan) ? timeout : new TimeSpan(0, 0, 1, 40);

                return client;
            }

            public T WebGet<T>(string url, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                return default(T);
            }
            public T WebGet<T>(string url, int id, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).PostAsJsonAsync(url, id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                return default(T);
            }

            public string WebGet(string url, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return string.Empty;
            }
            public T WebGet<T>(string url, T argument, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                return default(T);
            }
            public int WebPostResult<T>(string url, T argument, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).PostAsJsonAsync(url, argument).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                }
                return 0;
            }

            public string WebPost<T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).PostAsJsonAsync(url, argument).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return string.Empty;
            }

            public Y WebPost<Y, T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).PostAsJsonAsync(url, argument).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Y>().Result;
                }
                else if (response.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    var exceptionMessage = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                    throw new Exception(exceptionMessage.Message.ToString());
                }
                else
                {
                    var exceptionMessage = JsonConvert.DeserializeObject<HttpError>(response.Content.ReadAsStringAsync().Result).Message;
                    throw new Exception(exceptionMessage);
                }
            }

            public bool WebPostStatus<T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true)
            {
                var response = ServiceInit(timeout, automaticDecompression, url).PostAsJsonAsync(url, argument).Result;
                return response.IsSuccessStatusCode;
            }

        }

        public interface IServiceProxy
        {
            T WebGet<T>(string url, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true);
            T WebGet<T>(string url, int id, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true);
            string WebGet(string url, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true);
            T WebGet<T>(string url, T argument, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true);
            int WebPostResult<T>(string url, T argument, TimeSpan timeout = default(TimeSpan), bool automaticDecompression = true);
            string WebPost<T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true);
            Y WebPost<Y, T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true);
            bool WebPostStatus<T>(string url, T argument, TimeSpan timeout = default(TimeSpan),
                bool automaticDecompression = true);
        }
    
}