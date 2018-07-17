using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy;
using RESTy.Common;
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
            Assert.IsNotNull(response.Response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Response.Content));
            Assert.IsNotNull(response.Posts);

        }

        [TestMethod]
        public void GetAllUsers()
        {
            var request = new TypiCodePostRequest(homepage);

            var response = request.GET<TypiUserReponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Response.Content));
            Assert.IsNotNull(response.Users);

        }

        [TestMethod]
        public void GetAllUsersWithId()
        {
            var request = new TypiCodePostRequest(homepage);

            request.QueryParameters.Add(new KeyValue("userId", "1"));

            var response = request.GET<TypiUserReponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Response.Content));
            Assert.IsNotNull(response.Users);

        }
    }
}
