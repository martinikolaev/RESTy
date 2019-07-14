using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTy.Transaction;
using System;
using Tests.TestData.NegaviteScenarios;

namespace Tests
{
    [TestClass]
    public class RequiredFieldsTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RequiredPropertiesNotInstantiated()
        {
            var request = new DummyRequest();

            var response = request.GET<DummyResponse>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.")]
        public void RequiredPropertiesAreInstantiated()
        {
            var request = new DummyRequest2();

            var response = request.GET<DummyResponse>();
        }
    }
}
