using Newtonsoft.Json;
using RESTy.Common;
using System;

namespace Tests.TestData.DogApi
{
    public class RandomBreedsResponse : RESTFulResponse
    {
        #region Public Properties

        [JsonMap("$.message")]
        public string status { get; set; }

        [JsonProperty("message")]
        public string message { get;set; }

        #endregion

        public RandomBreedsResponse()
        {

        }
    }
}
