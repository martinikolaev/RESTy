using Newtonsoft.Json;
using RESTy.Common.Attributes;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Extensions
{
    internal static class PropertyInfoExtensions
    {
        #region Public Methods

        #region JsonPath Methods
        
        /// <summary>
        /// Checks if Property has JsonPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasJsonPathAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonPathAttribute));

        /// <summary>
        /// Gets the value of JsonPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetJsonPath(this PropertyInfo property) => property.GetCustomAttribute<JsonPathAttribute>().JsonPath;

        #endregion

        #region JsonProperty Methods

        /// <summary>
        /// Checks if the property has JsonPropertyAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasJsonAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonPropertyAttribute));


        /// <summary>
        /// Gets the value of JsonPropertyAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetJsonPropertyName(this PropertyInfo property) => property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;

        #endregion

        #region XPath Methods

        /// <summary>
        /// Checks if the property has XPathAttributes
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasXpathAttribute(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(XPathAttribute));

        /// <summary>
        /// Gets the value of XPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetXPath(this PropertyInfo property) => property.GetCustomAttribute<XPathAttribute>().XPath;
        #endregion

        #region Description Methods

        /// <summary>
        /// Checks if the property has XPathAttributes
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasDescription(this PropertyInfo property) => property.GetCustomAttributes().Any(a => a.GetType() == typeof(DescriptionAttribute));

        /// <summary>
        /// Gets the value of XPathAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetDescription(this PropertyInfo property) => property.GetCustomAttribute<DescriptionAttribute>().GetDescription();
        #endregion

        #endregion
    }
}
