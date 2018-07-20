using Newtonsoft.Json;
using RESTy.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RESTy.Common
{
    internal static class ContentProvider
    {
        #region Public Methods


        public static dynamic Provide<T>(T obj) where T: RESTFulRequest
        {
            switch (obj.ContentType)
            {
                case ContentType.None:
                    return null;
                case ContentType.Json:
                    return GetJsonContent(obj);
                case ContentType.Xml:
                    break;
                case ContentType.Form:
                    return GetFormContent(obj);
                default: throw new InvalidOperationException("Content of the object could not be recognized");
                    
            }
            return null;
        }
        
        /// <summary>
        /// Serializes any object into JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetJsonContent<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Deserialize JSON string to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        private static T Deserialize<T>(string jsonText)
        {
            return JsonConvert.DeserializeObject<T>(jsonText);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts RESTFulRequest object into Dictionary form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IDictionary<string, string> GetFormContent<T>(T obj) where T : RESTFulRequest
        {
            var form = new Dictionary<string, string>();
            var properties = obj
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetValue(obj, null) != null);

            foreach (PropertyInfo prop in properties)
            {
                var currentField = prop.GetValue(obj, null);

                if (prop.HasDescription())
                    form.Add(prop.GetDescription(), currentField.ToString());
                else
                    form.Add(prop.Name, currentField.ToString());
            }

            return form;
        }

        #endregion
    }
}
