using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RESTFulMap : Attribute
    {
        public RESTFulMap(string jsonProperty)
        {
            this.JsonProperty = jsonProperty;
        }

        public RESTFulMap(string jsonProperty, string jsonPath)
        {
            this.JsonPath = jsonPath;
            this.JsonProperty = JsonProperty;
        }

        public string JsonPath { get; private set; }
        public string JsonProperty { get; private set; }
    }
}
