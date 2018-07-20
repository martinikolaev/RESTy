using RESTy.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestData.ShibeOnline
{
    public class ShibesRequest : RESTFulRequest
    {
        public ShibesRequest()
        {
            this.Url = @"http://shibe.online/api/shibes?count=99&urls=true&httpsUrls=false";
            this.ContentType = ContentType.Json;
        }
    }
}
