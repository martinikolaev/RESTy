using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RESTy.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool HasJsonMapAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonMap));
        public static bool HasJsonAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonPropertyAttribute));


        public static string GetJsonMap(this PropertyInfo property) => property.GetCustomAttribute<JsonMap>().JsonPath;
        public static string GetJsonAttribute(this PropertyInfo property) => property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;

    }
}
