using RESTy.Transaction;
using RESTy.Transaction.Attributes;

namespace Tests.TestData.DogApi
{
    public class RandomBreedsRequest : RESTFulRequest
    {

        [Required]
        public string test { get; set; } = "50";

        public RandomBreedsRequest()
        {
            this.Url = @"https://dog.ceo/api/breed/hound/images/random";
            this.AcceptType = AcceptType.Form;
        }
    }
}
