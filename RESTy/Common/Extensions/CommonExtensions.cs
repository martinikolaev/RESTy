using Newtonsoft.Json;
using RESTy.Common.Attributes;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Extensions
{
    public static class CommonExtensions
    {
        public static string GetDescription<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .First()?
                            .GetCustomAttribute<DescriptionAttribute>()?
                            .GetDescription();

        public static string GetJsonPath<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .First()?
                            .GetCustomAttribute<JsonPathAttribute>()?
                            .JsonPath;

        public static string GetJsonProperty<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .First()?
                            .GetCustomAttribute<JsonPropertyAttribute>()?
                            .PropertyName;

    }
}
