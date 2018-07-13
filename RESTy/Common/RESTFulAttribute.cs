using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RESTFulAttribute : Attribute
    {
        public RESTFulAttribute(string jsonProperty)
        {
            this.JsonProperty = jsonProperty;
        }

        public RESTFulAttribute(string jsonProperty, string jsonPath)
        {
            this.JsonPath = jsonPath;
            this.JsonProperty = JsonProperty;
        }

        public string GetJsonProperty() => JsonProperty;

        public string GetJsonPath() => JsonPath;


        public string JsonPath { get; set; }
        public string JsonProperty { get; set; }
    }
}
