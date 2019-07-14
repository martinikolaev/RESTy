using RESTy.Transaction;

namespace RESTy.Templates
{
    class RequestTemplate : RESTFulRequest
    {
        public RequestTemplate()
        {
            this.Url = @"myUrl";
            this.AcceptType = AcceptType.Json;
        }
    }
}
