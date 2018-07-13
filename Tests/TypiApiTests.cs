using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestData.DogApi;
using Tests.TestData.TypiCode;

namespace Tests
{
    [TestClass]
    public class TypiApiTests
    {
        [TestMethod]
        public void GetAllPosts()
        {
            var request = new TypiCodePostRequest();

            var response = request.GET<TypiCodePostResponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Response.Content));

        }
    }
}
