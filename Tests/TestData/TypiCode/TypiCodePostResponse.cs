﻿using Newtonsoft.Json;
using RESTy.Common;

namespace Tests.TestData.TypiCode
{
    public class TypiCodePostResponse : RESTFulResponse
    {
        [JsonMap("$")]
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
