using RestSharp;
using RESTy.Transaction.Interfaces;
using System;

namespace RESTy.Transaction
{
    internal static class RESTfulResponseProcessor
    {
        //public static TResult ResponseProcessor<TResult>(RESTFulResponseInternal result)
        //    where TResult : IRESTfulResponse, new()
        //{

        //    if (result.IsSuccessStatusCode)
        //    {
        //        var instance = new TResult();

        //        instance = ContentReader.Reader(result.Content, instance);

        //        instance.Response = result;
        //        instance.Map();

        //        return instance;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException($"RESTful Exception: {result.StatusCode}\nError: {result.Content}");
        //    }
        //}

        internal static TResult ResponseProcessor<TResult>(IRestResponse result)
            where TResult : IRESTfulResponse, new()
        {

            if (result.IsSuccessful)
            {
                var instance = new TResult();

                instance = ContentReader.Reader(result.Content, instance);

                instance.InternalResponse = result;
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
