using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Commons
{
    public static class WebClientHelper
    {
        /// <summary>
        /// 以Post方式获取给定url的WebService值
        /// </summary>
        /// <typeparam name="T">返回值的类型</typeparam>
        /// <param name="url">WebService的地址</param>
        /// <param name="parameters">调用方法的参数</param>
        /// <returns>WebService的返回值</returns>
        public static string Post(string url, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var httpClient = new HttpClient();
            var response = httpClient.PostAsync(url, new FormUrlEncodedContent(parameters)).ContinueWith(p =>
            {
                string contentValue = p.Result.Content.ReadAsStringAsync().Result;
                return contentValue;
            });

            return response.Result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="json">需要的传值</param>
        /// <param name="url">访问的url</param>
        /// <param name="headers">头需要的键值对</param>
        /// <returns></returns>
        public static string Post(string json, string url, Dictionary<string, string> headers)
        {
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    content.Headers.Add(header.Key, header.Value);
                }
            }

            var response = httpClient.PostAsync(url, content).ContinueWith(p =>
            {
                string contentValue = p.Result.Content.ReadAsStringAsync().Result;
                return contentValue;
            });

            return response.Result;
        }

        /// <summary>
        /// 以Get方式获取给定url的WebService值
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns>Json值</returns>
        public static string Get(string requestUrl)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(requestUrl).ContinueWith(p =>
            {
                return p.Result.Content.ReadAsStringAsync().Result;
            });
            return response.Result;
        }

        public static T Get<T>(string requestUrl) where T : class
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(requestUrl).ContinueWith(p =>
            {
                string contentValue = p.Result.Content.ReadAsStringAsync().Result;
                T result = JsonConvert.DeserializeObject<T>(contentValue);
                return result;
            });

            return response.Result;
        }
    }
}
