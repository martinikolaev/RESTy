using RESTy.Common.Interfaces;
using System.Collections.Generic;

namespace RESTy.Common
{
    public abstract class RESTFulRequest : IRESTfulRequest
    {
        #region Public Properties

        public string Url { get; set; }
        public List<KeyValue> CustomHeaders { get; set; }
        public ContentType ContentType { get; set; }

        #endregion

        public RESTFulRequest()
        {
            this.CustomHeaders = new List<KeyValue>();
        }
    }
}
