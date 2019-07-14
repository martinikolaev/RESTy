using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy;
using RESTy.Transaction;
using Tests.TestData.TypiCode;

namespace Tests
{
    [TestClass]
    public class TypiApiTests
    {
        private string homepage = "https://jsonplaceholder.typicode.com";

        [TestMethod]
        public void GetAllPosts()
        {
            var request = new TypiCodePostRequest(homepage);

            var response = request.GET<TypiCodePostResponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsFalse(string.IsNullOrEmpty(response.InternalResponse.Content));
            Assert.IsNotNull(response.Posts);

        }

        [TestMethod]
        public void GetAllPostsRestSharp()
        {
            var request = new TypiCodePostRequest(homepage);

            var response = request.GET<TypiCodePostResponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsFalse(string.IsNullOrEmpty(response.InternalResponse.Content));
            Assert.IsNotNull(response.Posts);

        }

        [TestMethod]
        public void GetAllUsers()
        {
            var request = new TypiCodePostRequest(homepage);

            var response = request.GET<TypiUserReponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsFalse(string.IsNullOrEmpty(response.InternalResponse.Content));
            Assert.IsNotNull(response.Users);

        }

        [TestMethod]
        public void GetAllUsersWithId()
        {
            var request = new TypiCodePostRequest(homepage);

            request.QueryParameters.Add(new KeyValue("userId", "1"));

            var response = request.GET<TypiUserReponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsFalse(string.IsNullOrEmpty(response.InternalResponse.Content));
            Assert.IsNotNull(response.Users);

        }
    }
}
