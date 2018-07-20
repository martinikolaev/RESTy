using RESTy.Transaction;
using RESTy.Transaction.Attributes;
using System.Collections.Generic;

namespace Tests.TestData.ShibeOnline
{
    public class ShibesResponse : RESTFulResponse
    {
        #region Public Properties

        [JsonPath("$")]
        public List<string> Urls { get; set; }

        #endregion

        public ShibesResponse()
        {
            this.ContentType = ContentType.Json;

        }

        public override void Map()
        {

        }
    }

    
}
