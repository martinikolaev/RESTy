using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RESTFulMap : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonProperty"></param>
        public RESTFulMap(string jsonProperty)
        {
            this.JsonProperty = jsonProperty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonProperty"></param>
        /// <param name="jsonPath"></param>
        public RESTFulMap(string jsonProperty, string jsonPath)
        {
            this.JsonPath = jsonPath;
            this.JsonProperty = JsonProperty;
        }

        public string JsonPath { get; private set; }
        public string JsonProperty { get; private set; }
    }
}
