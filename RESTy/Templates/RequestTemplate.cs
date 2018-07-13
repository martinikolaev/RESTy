using RESTy.Common;

namespace RESTy.Templates
{
    public class RequestTemplate : RESTFulRequest
    {
        public RequestTemplate()
        {
            this.Url = @"myUrl";
            this.ContentType = ContentType.Json;
        }
    }
}
