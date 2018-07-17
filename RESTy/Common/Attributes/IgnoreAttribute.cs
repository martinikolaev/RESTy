using System;

namespace RESTy.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IgnoreAttribute : Attribute
    {

    }
}
