using RESTy.Transaction.RestMethods.Common;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RESTy.Transaction.RestMethods
{
    internal static class DeleteMethod
    {
        public static RESTFulResponseInternal Delete(string url, string acceptType, Dictionary<string, string> requestHeaders)
        {
            return DeleteInternal(url, acceptType, requestHeaders);
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
            using (var httpClient = HttpClientProvider.CreateHttpClient(requestHeaders))
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
    }
}
