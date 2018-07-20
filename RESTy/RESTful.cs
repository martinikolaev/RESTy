using RESTy.Common;
using RESTy.Common.Extensions;
using RESTy.Common.Interfaces;
using RESTy.Common.RestMethods;

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

            var result = GetMethod.Get(url, contentType, headers);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult POST<TResult>(this RESTFulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            var url = obj.Url;
            var content = ContentProvider.Provide(obj);
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

            var result = PostMethod.Post(obj.Url, content, contentType, headers);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult PUT<TResult>(this RESTFulRequest obj, string securityToken = "")
            where TResult : IRESTfulResponse, new()
        {
            if (obj == null) return default(TResult);

            var url = obj.Url;
            var content = ContentProvider.Provide(obj);
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(securityToken, obj.RequestHeaders.ToArray());

            var result = PutMethod.Put(obj.Url, content, contentType, headers);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        public static TResult DELETE<TResult>(this RESTFulRequest obj, string accessToken = "")
            where TResult : IRESTfulResponse, new()
        {

            if (obj == null) return default(TResult);

            var url = obj.Url;
            var contentType = obj.ContentType.GetDescription();
            var headers = HeaderProvider.GetHeaders(accessToken, obj.RequestHeaders.ToArray());

            var result = DeleteMethod.Delete(obj.Url, contentType, headers);

            return RESTfulResponseProcessor.ResponseProcessor<TResult>(result);
        }

        #endregion
    }
}
