using System;

namespace RESTy.Common
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string value)
        {
            this.Value = value;
        }

        private string Value { get; }

        public string GetDescription() => Value;
    }
}
