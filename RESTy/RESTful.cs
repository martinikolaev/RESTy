using RESTy.Common;
using RESTy.Transaction.Extensions;
using RESTy.Transaction.Interfaces;
using RESTy.Transaction.RestMethods;

namespace RESTy.Transaction
{
    public static partial class RESTFul
    {
        #region Public Methods

        //public static TResult GET<TResult>(this IRESTfulRequest obj, string securityToken = "")
        //    where TResult : IRESTfulResponse, new()
        //{
        //    if (obj == null) return default(TResult);

        //    RequestValidator.Validate(obj);

        //    var url = obj.Url;
        //    var acceptType = obj.AcceptType.GetDescription();
        //    var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

        //    var result = GetMethod.Get(url, acceptType, headers);

        //    return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        //}

        //public static TResult POST<TResult>(this IRESTfulRequest obj, string securityToken = "")
        //    where TResult : IRESTfulResponse, new()
        //{
        //    if (obj == null) return default(TResult);
        //    TransactionValidator.RequestValidator(obj);

        //    var url = obj.Url;
        //    var content = ContentProvider.Provider((RESTFulRequest)obj);
        //    var acceptType = obj.AcceptType.GetDescription();
        //    var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

        //    var result = PostMethod.Post(obj.Url, content, acceptType, headers);

        //    return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        //}

        //public static TResult PUT<TResult>(this IRESTfulRequest obj, string securityToken = "")
        //    where TResult : IRESTfulResponse, new()
        //{
        //    if (obj == null) return default(TResult);
        //    TransactionValidator.RequestValidator(obj);

        //    var url = obj.Url;
        //    var content = ContentProvider.Provider((RESTFulRequest)obj);
        //    var acceptType = obj.AcceptType.GetDescription();
        //    var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

        //    var result = PutMethod.Put(obj.Url, content, acceptType, headers);

        //    return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        //}

        //public static TResult DELETE<TResult>(this IRESTfulRequest obj, string accessToken = "")
        //    where TResult : IRESTfulResponse, new()
        //{

        //    if (obj == null) return default(TResult);
        //    TransactionValidator.RequestValidator(obj);

        //    var url = obj.Url;
        //    var acceptType = obj.AcceptType.GetDescription();
        //    var headers = HeaderProvider.GetHeaders(accessToken, obj.RequestHeaders.ToArray());

        //    var result = DeleteMethod.Delete(obj.Url, acceptType, headers);

        //    return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        //}

        #endregion
    }
}
