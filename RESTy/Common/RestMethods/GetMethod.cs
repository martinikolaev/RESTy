using RESTy.Transaction.RestMethods.Common;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RESTy.Transaction.RestMethods
{
    internal class GetMethod
    {
        public static RESTFulResponseInternal Get(string url, string acceptType, Dictionary<string, string> requestHeaders)
        {
            return GetInternal(url, acceptType, requestHeaders);
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
            using (var httpClient = HttpClientProvider.CreateHttpClient(requestHeaders))
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
    }
}
