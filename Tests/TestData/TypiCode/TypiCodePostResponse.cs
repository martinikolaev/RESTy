using Newtonsoft.Json;
using RESTy.Transaction;
using RESTy.Transaction.Attributes;

namespace Tests.TestData.TypiCode
{
    public class TypiCodePostResponse : RESTFulResponse
    {
        public TypiCodePostResponse()
        {
            this.ContentType = ContentType.Json;
        }

        [JsonPath("$")]
        [JsonProperty("TestProperty")]
        public Post[] Posts { get; set; }

        public override void Map()
        {

        }
    }

    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
