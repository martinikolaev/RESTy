using RestSharp;
using RESTy.Common;
using RESTy.Common.RestMethods.Common;
using RESTy.Transaction.Interfaces;

namespace RESTy.Transaction
{
    public static partial class RESTFul
    {
        #region Public Methods

        public static TResult GET<TResult>(this IRESTfulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            TransactionValidator.RequestValidator(obj);

            var acceptType = obj.AcceptType;


            var client = new BaseClient(obj.Url, securityToken);
            var request = new RestRequest(obj.Url, Method.GET, DataFormat.Json);

            var headers = HeaderProvider.GetRestHeaders(obj.RequestHeaders.ToArray());

            request.Parameters.AddRange(headers);

            var result = client.Execute<TResult>(request);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult POST<TResult>(this IRESTfulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);
            TransactionValidator.RequestValidator(obj);

            var client = new BaseClient(obj.Url, securityToken);
            var request = client.ObjectShredder(obj, Method.POST, DataFormat.Json);
            
            var result = client.Execute<TResult>(request);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult PUT<TResult>(this IRESTfulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);
            TransactionValidator.RequestValidator(obj);

            var client = new BaseClient(obj.Url, securityToken);
            var request = client.ObjectShredder(obj, Method.PUT, DataFormat.Json);

            var result = client.Execute<TResult>(request);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult DELETE<TResult>(this IRESTfulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {

            if (obj == null) return default(TResult);
            TransactionValidator.RequestValidator(obj);

            var client = new BaseClient(obj.Url, securityToken);
            var request = client.ObjectShredder(obj, Method.DELETE, DataFormat.Json);

            var result = client.Execute<TResult>(request);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        #endregion
    }
}
