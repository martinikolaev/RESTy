using System;

namespace RESTy.Transaction.Attributes
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class XPathAttribute : Attribute
    {

        /// <summary>
        /// JSON mapping with JsonPath
        /// </summary>
        /// <param name="xpath"></param>
        public XPathAttribute(string xpath)
        {
            this.XPath = xpath;
        }

        public string XPath { get; private set; }

    }
}
