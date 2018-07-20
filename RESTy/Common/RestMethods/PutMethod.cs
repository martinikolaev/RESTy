using RESTy.Common.RestMethods.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RESTy.Common.RestMethods
{
    public static class PutMethod
    {

        public static RESTFulResponseInternal Put(string url, object content, string contentType, Dictionary<string, string> requestHeaders)
        {
            return PutInternal(url, content, contentType, requestHeaders);
        }


        private static RESTFulResponseInternal PutInternal(string url, object content, string contentType, Dictionary<string, string> requestHeaders)
        {
            // Create http client with auto disposition
            using (var httpClient = HttpClientProvider.CreateHttpClient(requestHeaders))
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
    }
}
