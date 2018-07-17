using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RESTy.Common
{
    public abstract class RESTFulRequest : IRESTfulRequest
    {
        #region Public Properties

        private string baseUrl { get; set; }

        public string Url { get => this.GetUrl(); set => baseUrl = value; }
        public List<KeyValue> RequestHeaders { get; set; }
        public ContentType ContentType { get; set; }
        public List<KeyValue> QueryParameters { get; set; }

        #endregion

        public RESTFulRequest()
        {
            this.RequestHeaders = new List<KeyValue>();
            this.QueryParameters = new List<KeyValue>();
        }


        #region Public Methods

        public List<KeyValue> GetParameters() => QueryParameters;
        public void AddGetParameter(KeyValue keyValue) => QueryParameters.Add(keyValue);
        public void AddRangeGetParameters(List<KeyValue> keyValue) => QueryParameters.AddRange(keyValue);
        public void RemoveGetParameter(KeyValue keyValue) => QueryParameters.Remove(keyValue);


        #endregion

        #region Private Methods

        private string GetUrl()
        {
            if (string.IsNullOrEmpty(baseUrl)) throw new InvalidOperationException($"{nameof(baseUrl)} is empty!");

            var urlSb = new StringBuilder($"{baseUrl}");

            if (this.QueryParameters.Any())
            {
                urlSb.Append("?");

                foreach (var keyValue in this.QueryParameters)
                {
                    urlSb.Append($"{keyValue.Key}={keyValue.Value}");
                }
            }
            
            return urlSb.ToString();
        }
        #endregion
    }
}
