using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class JsonMap : Attribute
    {
        /// <summary>
        /// JSON mapping with JsonPath
        /// </summary>
        /// <param name="jsonProperty"></param>
        public JsonMap(string jsonPath)
        {
            this.JsonPath = jsonPath;
        }
        
        public string JsonPath { get; private set; }
    }
}
