using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Checks if Property has JsonPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasJsonPathAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonPathAttribute));

        /// <summary>
        /// Checks if the property has JsonPropertyAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasJsonAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonPropertyAttribute));


        /// <summary>
        /// Gets the value of JsonPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetJsonPath(this PropertyInfo property) => property.GetCustomAttribute<JsonPathAttribute>().JsonPath;

        /// <summary>
        /// Gets the value of JsonPropertyAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetJsonProperty(this PropertyInfo property) => property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;

    }
}
