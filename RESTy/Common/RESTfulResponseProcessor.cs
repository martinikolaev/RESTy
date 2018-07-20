using RESTy.Common.Interfaces;
using System;

namespace RESTy.Common
{
    internal static class RESTfulResponseProcessor
    {
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
    }
}
