using System;

namespace RESTy.Transaction.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class JsonPathAttribute : Attribute
    {
        /// <summary>
        /// JSON mapping with JsonPath
        /// </summary>
        /// <param name="jsonProperty"></param>
        public JsonPathAttribute(string jsonPath)
        {
            this.JsonPath = jsonPath;
        }
        
        public string JsonPath { get; private set; }
    }
}
