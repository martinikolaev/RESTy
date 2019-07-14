using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy.Transaction;
using Tests.TestData.DogApi;

namespace Tests
{
    [TestClass]
    public class DogApiTests
    {
        [TestMethod]
        public void GetRandomBreedImage()
        {
            var request = new RandomBreedsRequest();

            var response = request.POST<RandomBreedsResponse>();

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.message));
            Assert.IsFalse(string.IsNullOrEmpty(response.status));
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsFalse(string.IsNullOrEmpty(response.InternalResponse.Content));

        }
    }
}
