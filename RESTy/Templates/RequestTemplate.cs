using RESTy.Transaction;

namespace RESTy.Templates
{
    class RequestTemplate : RESTFulRequest
    {
        public RequestTemplate()
        {
            this.Url = @"myUrl";
            this.ContentType = ContentType.Json;
        }
    }
}
