﻿using System;

namespace RESTy.Transaction.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IgnoreAttribute : Attribute
    {

    }
}
