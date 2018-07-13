using System.Collections.Generic;
using System.Linq;

namespace RESTy.Common
{
    public class KeyValue
    {
        public KeyValue()
        {

        }

        public KeyValue(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }

    public class HeaderProvider
    {

        public static Dictionary<string, string> GetHeaders(string accessToken, params KeyValue[] keyValues)
        {
            var headerCollection = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(accessToken))
            {
                headerCollection = new Dictionary<string, string>
                {
                    ["Authorization"] = $"Bearer {accessToken}"
                };
            }

            if (keyValues != null && keyValues.Length > 0)
            {
                keyValues.ToList().ForEach(k => headerCollection.Add(k.Key, k.Value));
            }

            return headerCollection;
        }
    }
}
