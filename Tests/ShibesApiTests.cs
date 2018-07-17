using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy;
using Tests.TestData.ShibeOnline;

namespace Tests
{
    [TestClass]
    public class ShibesApiTests
    {
        [TestMethod]
        public void ShibesTest()
        {
            var request = new ShibesRequest();

            var response = request.GET<ShibesResponse>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Response);
            Assert.IsNotNull(response.Urls);
            Assert.IsTrue(response.Urls.Any());
        }
    }
}
