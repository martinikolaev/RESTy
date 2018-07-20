using RESTy.Transaction;

namespace Tests.TestData.DogApi
{
    public class RandomBreedsRequest : RESTFulRequest
    {
        public RandomBreedsRequest()
        {
            this.Url = @"https://dog.ceo/api/breed/hound/images/random";
            this.AcceptType = AcceptType.Json;
        }
    }
}
