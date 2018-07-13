using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace RESTy.Common.Extensions
{
    public static class CommonExtensions
    {

        
        public static string GetJsonPath<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .First()?
                            .GetCustomAttribute<JsonMap>()?
                            .JsonPath;

        public static string GetJsonProperty<T>(this T obj) => obj.GetType()
                            .GetMember(obj.ToString())?
                            .First()?
                            .GetCustomAttribute<JsonPropertyAttribute>()?
                            .PropertyName;

    }
}
