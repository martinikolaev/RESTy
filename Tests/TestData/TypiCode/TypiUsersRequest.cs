using RESTy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestData.TypiCode
{
    public class TypiUsersRequest : RESTFulRequest
    {
        public TypiUsersRequest(string homeUrl)
        {
            this.Url = $@"{homeUrl}/users";
            this.ContentType = ContentType.Json;
        }
    }


    
}
