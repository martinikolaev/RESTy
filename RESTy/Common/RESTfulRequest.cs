using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common
{
    public abstract class RESTFulRequest
    {

        #region Public Fields

        public string Url { get; set; }
        public ContentType ContentType { get; set; }
        public List<KeyValue> CustomHeaders { get; set; }

        #endregion

        #region Public Constuctors

        public RESTFulRequest()
        {
            this.CustomHeaders = new List<KeyValue>();
        }

        #endregion

    }
}
