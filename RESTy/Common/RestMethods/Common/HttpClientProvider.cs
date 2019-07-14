using RestSharp;
using System.Collections.Generic;
using System.Net.Http;

namespace RESTy.Transaction.RestMethods.Common
{
    internal class HttpClientProvider
    {
        /// <summary>
        /// Creates the http client with the specified request headers.
        /// </summary>
        /// <param name="requestHeaders">The collection having request headers.</param>
        /// <returns>The http client object.</returns>
        public static HttpClient CreateHttpClient(IReadOnlyDictionary<string, string> requestHeaders)
        {
            // Declares local variables
            HttpClient httpClient = new HttpClient();


            //TODO:: Add network default logic
            //var authtHandler = new HttpClientHandler()
            //{
            //    Credentials = CredentialCache.DefaultNetworkCredentials
            //};

            //httpClient = new HttpClient(authtHandler);



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
    }
}
