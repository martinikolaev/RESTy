using System;

namespace RESTy.Transaction.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : Attribute
    {
    }
}
