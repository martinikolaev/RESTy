using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class Description : Attribute
    {
        public Description(string value)
        {
            this.Value = value;
        }

        private string Value { get; }

        public string GetDescription() => Value;
    }
}
