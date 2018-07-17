using RESTy.Common;
using RESTy.Common.Attributes;

namespace Tests.TestData.DogApi
{
    public class RandomBreedsResponse : RESTFulResponse
    {
        #region Public Properties

        [JsonPath("$.message")]
        public string status { get; set; }

        public string message { get;set; }

        #endregion

        public RandomBreedsResponse()
        {
            this.ContentType = ContentType.Json;
        }
    }
}
