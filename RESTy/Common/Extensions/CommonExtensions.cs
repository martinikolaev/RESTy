using Newtonsoft.Json;
using RESTy.Transaction.Attributes;
using System.Linq;
using System.Reflection;

namespace RESTy.Transaction.Extensions
{
    internal static class CommonExtensions
    {
        public static string GetDescription<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .FirstOrDefault()?
                            .GetCustomAttribute<DescriptionAttribute>()?
                            .GetDescription();

        public static string GetJsonPath<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .FirstOrDefault()?
                            .GetCustomAttribute<JsonPathAttribute>()?
                            .JsonPath;

        public static string GetJsonProperty<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .FirstOrDefault()?
                            .GetCustomAttribute<JsonPropertyAttribute>()?
                            .PropertyName;

    }
}
