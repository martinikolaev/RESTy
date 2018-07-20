using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RESTy.Transaction.Helpers
{
    internal static class Reflection
    {
        /// <summary>
        /// Gets all non-inherited properties of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetProperties<T>(T obj)
        {
            return obj
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        /// <summary>
        /// Gets all properties of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetAllProperties<T>(T obj)
        {
            return obj
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        }
    }
}
