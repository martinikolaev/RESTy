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

    internal class HeaderProvider
    {
        /// <summary>
        /// Returns all headers default and custom
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetHeaders(string securityToken, params KeyValue[] keyValues)
        {
            var headerCollection = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(securityToken))
            {
                headerCollection.Add("Authorization", $"Bearer {securityToken}");
            }

            if (keyValues != null && keyValues.Length > 0)
            {
                keyValues.ToList().ForEach(k => headerCollection.Add(k.Key, k.Value));
            }

            return headerCollection;
        }
    }
}
