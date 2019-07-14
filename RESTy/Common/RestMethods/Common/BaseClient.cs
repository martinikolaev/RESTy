using RestSharp;
using RESTy.Transaction;
using RESTy.Transaction.Extensions;
using RESTy.Transaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common.RestMethods.Common
{

    internal class BaseClient
    {
        private RestClient RestClient;

        private readonly string BaseUrl;
        private readonly string AccessToken;


        public BaseClient(string baseUrl)
        {
            this.BaseUrl = baseUrl;

            this.RestClient = new RestClient(baseUrl)
            {
                Timeout = 10000
            };
        }

        public BaseClient(string baseUrl, string access_token)
        {
            this.BaseUrl = baseUrl;
            this.AccessToken = access_token;
            this.RestClient = new RestClient(baseUrl);
        }

        internal IRestResponse Execute<T>(RestRequest request) where T : new()
        {
            if(!string.IsNullOrWhiteSpace(AccessToken))
                request.AddParameter("Authorization", $"Bearer {AccessToken}", ParameterType.HttpHeader);



            var response = RestClient.Execute(request);

            if(response.ErrorException != null)
            {
                string message = $"RESTful Exception: { response.StatusCode}\nError: { response.ErrorException}";
                throw new InvalidOperationException(message);                
            }

            return response;
        }


        /// <summary>
        /// Shredding an object into an Rest Request
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal RestRequest ObjectShredder(IRESTfulRequest obj, Method method, DataFormat dataFormat)
        {
            var request = new RestRequest(obj.Url, method, dataFormat);

            var content = ContentProvider.Provider((RESTFulRequest)obj);
            var acceptType = obj.AcceptType.GetDescription();
            var headers = HeaderProvider.GetRestHeaders(obj.RequestHeaders.ToArray());

            request.Parameters.AddRange(headers);

            //request.Parameters.AddRange(content);

            //request.AddJsonBody((RESTFulRequest)obj);

            request.AddParameter("application/json; charset=utf-8", content, ParameterType.RequestBody);



            return request;
        }
    }
}
