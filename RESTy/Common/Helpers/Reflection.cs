using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Helpers
{
    public static class Reflection
    {
        public static List<PropertyInfo> GetProperties<T>(T obj)
        {
            return obj
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
        }
    }
}
