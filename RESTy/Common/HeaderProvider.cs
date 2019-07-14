using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace RESTy.Transaction
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

        public static List<Parameter> GetRestHeaders(params KeyValue[] keyValues)
        {
            var headerCollection = new List<Parameter>();

            if (keyValues != null && keyValues.Length > 0)
            {
                keyValues.ToList().ForEach(k => headerCollection.Add(new Parameter(k.Key, k.Value, ParameterType.HttpHeader)));
            }

            return headerCollection;
        }
    }
}

