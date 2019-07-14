using RESTy.Transaction;
using RESTy.Transaction.Attributes;

namespace Tests.TestData.NegaviteScenarios
{
    public class DummyRequest : RESTFulRequest
    {

        [Required]
        public string TestString { get; set; }

        public DummyRequest()
        {
            
            //this.AcceptType = AcceptType.Json;
        }
    }

    public class DummyRequest2 : RESTFulRequest
    {

        [Required]
        public string TestString { get; set; } = "test2";

        public DummyRequest2()
        {
            this.Url = "http://blahblah.com";
            this.AcceptType = AcceptType.Json;
        }
    }
}
