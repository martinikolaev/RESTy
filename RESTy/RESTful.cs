using RESTy.Common;
using RESTy.Common.Extensions;
using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RESTy
{
    public static class RESTFul
    {
        #region Public Fields

        #endregion

        #region Public Methods

        public static TResult GET<TResult>(this RESTFulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            var url = obj.Url;
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());


            var result = RESTFul.GetInternal(url, contentType, headers);

            return RESTFul.ResponseProcessor<TResult>(result);
        }

        public static TResult POST<TResult>(this RESTFulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            var url = obj.Url;
            var content = ContentProvider.GetContent(obj);
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

            var result = RESTFul.PostInternal(obj.Url, content, contentType, headers);

            return RESTFul.ResponseProcessor<TResult>(result);
        }

        public static TResult PUT<TResult>(this RESTFulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            var url = obj.Url;
            var content = ContentProvider.GetContent(obj);
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

            var result = RESTFul.PutInternal(obj.Url, content, contentType, headers);

            return ResponseProcessor<TResult>(result);
        }

        public static TResult DELETE<TResult>(this RESTFulRequest obj, string accessToken = "")
            where TResult : IRESTfulResponse, new()
        {

            if (obj == null) return default(TResult);

            var url = obj.Url;
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(accessToken, obj.RequestHeaders.ToArray());

            var result = RESTFul.DeleteInternal(obj.Url, contentType, headers);

            return ResponseProcessor<TResult>(result);
        }

        #endregion

        #region Private Methods

        public static TResult ResponseProcessor<TResult>(RESTFulResponseInternal result)
            where TResult : IRESTfulResponse, new()
        {
            if (result.IsSuccessStatusCode)
            {
                var instance = new TResult();
                
                instance = ContentReader.Reader(result.Content, instance);

                instance.Response = result;
                instance.Map();

                return instance;
            }
            else
            {
                throw new InvalidOperationException($"RESTful Exception: {result.StatusCode}\nError: {result.Content}");
            }
        }
        
        #region RESTFul Methods

        /// <summary>
        /// Creates the http client with the specified request headers.
        /// </summary>
        /// <param name="requestHeaders">The collection having request headers.</param>
        /// <returns>The http client object.</returns>
        private static HttpClient CreateHttpClient(IReadOnlyDictionary<string, string> requestHeaders)
        {
            var isWebRequest = requestHeaders != null && requestHeaders.ContainsKey("Authorization") && !string.IsNullOrEmpty(requestHeaders["Authorization"]);

            // Declares local variables
            HttpClient httpClient;

            if (isWebRequest)
            {
                httpClient = new HttpClient();
            }
            else
            {
                var authtHandler = new HttpClientHandler()
                {
                    Credentials = CredentialCache.DefaultNetworkCredentials
                };

                httpClient = new HttpClient(authtHandler);
            }

            // Add request headers in the http client
            if (requestHeaders != null && requestHeaders.Count > 0)
            {
                httpClient.DefaultRequestHeaders.Clear();
                foreach (var header in requestHeaders)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            // Return the http client
            return httpClient;
        }


        /// <summary>
        /// Calls the REST api with POST method.
        /// </summary>
        /// <param name="url">The url for the REST api.</param>
        /// <param name="content">The content for the REST api.</param>
        /// <param name="contentType">The content type string.</param>
        /// <param name="requestHeaders">The request headers for the REST api.</param>
        /// <returns>The http response having status code and content.</returns>
        private static RESTFulResponseInternal PostInternal(string url, object content, string contentType, Dictionary<string, string> requestHeaders)
        {
            // Create http client with auto disposition
            using (var httpClient = CreateHttpClient(requestHeaders))
            {
                // Add 'Accept' header in the request
                if (requestHeaders != null && requestHeaders.All(rh => rh.Key != HttpRequestHeader.Accept.ToString()))
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(contentType));
                }

                // Build the http content
                HttpContent httpContent = null;

                if (contentType.ToLower().Contains("form"))
                {
                    httpContent = new FormUrlEncodedContent(content as Dictionary<string, string>);
                }
                else if (contentType.ToLower().Contains("json"))
                {
                    var jsonContent = content is string ? content.ToString() : ContentProvider.GetJsonContent(content);
                    httpContent = new StringContent(jsonContent, Encoding.UTF8, contentType);
                }

                // Call the REST api with POST method
                var result = httpClient.PostAsync(url, httpContent).Result;

                // Get the response content
                var responseContent = result.Content.ReadAsStringAsync().Result;

                // Return the RESTFul response
                return new RESTFulResponseInternal(result.StatusCode, result.IsSuccessStatusCode, responseContent);
            }
        }

        private static RESTFulResponseInternal PutInternal(string url, object content, string contentType, Dictionary<string, string> requestHeaders)
        {
            // Create http client with auto disposition
            using (var httpClient = CreateHttpClient(requestHeaders))
            {
                // Add 'Accept' header in the request
                if (requestHeaders != null && requestHeaders.All(rh => rh.Key != HttpRequestHeader.Accept.ToString()))
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(contentType));
                }

                // Build the http content
                HttpContent httpContent = null;

                if (contentType.ToLower().Contains("form"))
                {
                    httpContent = new FormUrlEncodedContent(content as Dictionary<string, string>);
                }
                else if (contentType.ToLower().Contains("json"))
                {
                    var jsonContent = content is string ? content.ToString() : ContentProvider.GetJsonContent(content);
                    httpContent = new StringContent(jsonContent, Encoding.UTF8, contentType);
                }

                // Call the REST api with POST method
                var result = httpClient.PutAsync(url, httpContent).Result;

                // Get the response content
                var responseContent = result.Content.ReadAsStringAsync().Result;

                // Return the RESTFul response
                return new RESTFulResponseInternal(result.StatusCode, result.IsSuccessStatusCode, responseContent);
            }
        }

        /// <summary>
        /// Calls the REST api with GET method.
        /// </summary>
        /// <param name="url">The url for the REST api.</param>
        /// <param name="acceptType">The accept type string.</param>
        /// <param name="requestHeaders">The request headers for the REST api.</param>
        /// <returns>The http response having status code and content.</returns>
        private static RESTFulResponseInternal GetInternal(string url, string acceptType, Dictionary<string, string> requestHeaders)
        {
            // Create http client with auto disposition
            using (var httpClient = CreateHttpClient(requestHeaders))
            {
                // Add 'Accept' header in the request
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(acceptType));

                // Call the REST api with GET method
                var result = httpClient.GetAsync(url).Result;

                // Get the response content
                var responseContent = result.Content.ReadAsStringAsync().Result;

                // Return the RESTFul response
                return new RESTFulResponseInternal(result.StatusCode, result.IsSuccessStatusCode, responseContent);
            }
        }

        /// <summary>
        /// Calls the REST api with DELETE method.
        /// </summary>
        /// <param name="url">The url for the REST api.</param>
        /// <param name="acceptType">The accept type string.</param>
        /// <param name="requestHeaders">The request headers for the REST api.</param>
        /// <returns></returns>
        private static RESTFulResponseInternal DeleteInternal(string url, string acceptType, Dictionary<string, string> requestHeaders)
        {
            // Create http client with auto disposition
            using (var httpClient = CreateHttpClient(requestHeaders))
            {
                // Add 'Accept' header in the request
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(acceptType));

                // Call the REST api with DELETE method
                var result = httpClient.DeleteAsync(url).Result;

                // Get the response content
                var responseContent = result.Content.ReadAsStringAsync().Result;

                // Return the RESTFul response
                return new RESTFulResponseInternal(result.StatusCode, result.IsSuccessStatusCode, responseContent);
            }
        }

        //private static T GetInstance<T>(HttpStatusCode statusCode, bool isSuccessStatusCode, string content) where T : RESTFulResponse, new()
        //{
        //    var args = new object[] { statusCode, isSuccessStatusCode, content };

        //    return (T)Activator.CreateInstance(typeof(T), args);
        //}
        #endregion

        #endregion
    }

}
