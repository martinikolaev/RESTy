using RESTy.Common;
using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestData.TypiCode
{
    public class TypiCodePostRequest : RESTFulRequest
    {
        public TypiCodePostRequest()
        {
            this.Url = @"myUrl";
            this.ContentType = ContentType.Json;

        }
    }
}
