using RESTy.Common;

namespace Tests.TestData.TypiCode
{
    public class TypiCodePostRequest : RESTFulRequest
    {
        public TypiCodePostRequest()
        {
            this.Url = "https://jsonplaceholder.typicode.com/posts";
            this.ContentType = ContentType.Json;
        }
    }
}
