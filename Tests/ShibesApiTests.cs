using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy.Transaction;
using System.Linq;
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
            Assert.IsNotNull(response.InternalResponse);
            Assert.IsNotNull(response.Urls);
            Assert.IsTrue(response.Urls.Any());
        }
    }
}
