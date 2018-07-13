using RESTy.Common;
using System;

namespace Tests.TestData.DogApi
{
    public class RandomBreedsResponse : RESTFulResponse
    {
        #region Public Properties

        public string status { get; set; }
        public string message { get;set; }

        #endregion

        public RandomBreedsResponse()
        {

        }
    }
}
