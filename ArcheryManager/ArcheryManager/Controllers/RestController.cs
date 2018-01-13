using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryManager.Controllers
{
    public class RestController
    {
        /// <summary>
        ///  default of buffer size
        /// </summary>
        private const int DefaultBufferSize = 256000;

        private const string GeneralErrorMessage = "error durring getting value on the server";

        private const string JsonMediaType = "application/json";

        /// <summary>
        /// url of the rest server
        /// </summary>
        private readonly string serverUrl;

        static RestController()
        {
            JsonConvert.DefaultSettings = () =>
            {
                return new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                    Error = (sender, args) =>
                    {
                        if (System.Diagnostics.Debugger.IsAttached)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                    }
                };
            };
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="url">url of the server</param>
        /// <param name="bufferSize">buffer size of the client</param>
        public RestController(string url, int bufferSize = DefaultBufferSize)
        {
            serverUrl = url;
        }

        public static string AddParamToUri(string uri, Dictionary<string, object> param)
        {
            if (param == null
            || param.Count == 0)
                return uri;

            uri += "?";

            int index = 0;
            foreach (var val in param)
            {
                index++;
                uri += val.Key + "=";
                uri += JsonConvert.SerializeObject(val.Value);

                if (index < param.Count)
                    uri += "&";
            }

            return uri;
        }

        /// <summary>
        /// get consummation of the server
        /// </summary>
        /// <typeparam name="T">type of the return</typeparam>
        /// <param name="function">function to consume</param>
        /// <returns>result of the function</returns>
        public async Task<T> GetAsync<T>(string function, Dictionary<string, object> param = null) // test param
        {
            string url = serverUrl + function;
            url = AddParamToUri(url, param);

            using (var httpClientHandler = new HttpClientHandler()
            {
                UseDefaultCredentials = false
            })

                try
                {
                    using (var client = new HttpClient(httpClientHandler)
                    {
                        BaseAddress = new Uri(url),
                        Timeout = TimeSpan.FromSeconds(15),
                    })
                    {
                        using (var response = await client.GetAsync(url))
                        {
                            using (var jsonStream = await response.Content.ReadAsStreamAsync())
                            {
                                using (var sr = new StreamReader(jsonStream))
                                {
                                    //  var t = sr.ReadToEnd();
                                    using (var jtr = new JsonTextReader(sr))
                                    {
                                        var js = new JsonSerializer();
                                        return js.Deserialize<T>(jtr);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
        }

        /// <summary>
        /// post consummation of the server
        /// </summary>
        /// <typeparam name="T">type of the object send</typeparam>
        /// <param name="function">function to consume</param>
        /// <param name="param">param to post</param>
        public async Task<T> PostAsync<T>(string function, object param = null, Action IsNotSuccessCallBack = null)
        {
            HttpResponseMessage response = null;

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.UseDefaultCredentials = false;

                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(serverUrl);
                    client.Timeout = TimeSpan.FromSeconds(15);
                    using (var content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json"))
                    {
                        var requestTask = client.PostAsync(serverUrl + function, content);

                        using (response = Task.Run(() => requestTask).Result)
                        {
                            using (var jsonStream = await response.Content.ReadAsStreamAsync())
                            {
                                using (var sr = new StreamReader(jsonStream))
                                {
                                    using (var jtr = new JsonTextReader(sr))
                                    {
                                        var js = new JsonSerializer();
                                        return js.Deserialize<T>(jtr);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public async Task<T> PutAsync<T>(string function, string param = "", object body = null)
        {
            string url = serverUrl + function + param;

            using (var httpClientHandler = new HttpClientHandler()
            {
                UseDefaultCredentials = false
            })
            {
                using (var client = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(url),
                    Timeout = TimeSpan.FromSeconds(15),
                })

                using (var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"))
                {
                    var requestTask = client.PutAsync(url, content);
                    using (var response = Task.Run(() => requestTask).Result)
                    {
                        using (var jsonStream = await response.Content.ReadAsStreamAsync())
                        {
                            using (var sr = new StreamReader(jsonStream))
                            {
                                //  var t = sr.ReadToEnd();
                                using (var jtr = new JsonTextReader(sr))
                                {
                                    var js = new JsonSerializer();
                                    return js.Deserialize<T>(jtr);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
