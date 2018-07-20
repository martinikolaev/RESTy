using System;

namespace RESTy.Transaction.Attributes
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
