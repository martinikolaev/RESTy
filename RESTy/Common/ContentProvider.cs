using Newtonsoft.Json;
using RESTy.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RESTy.Common
{
    public static class ContentProvider
    {
        #region Public Methods


        /// <summary>
        /// Transforms the object into a selected content type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static dynamic GetContent<T>(T obj) where T : RESTFulRequest
        {
            if (obj.ContentType == ContentType.Form)
                return GetFormContent(obj);
            else if (obj.ContentType == ContentType.Json)
                return GetJsonContent(obj);

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
        public static T Deserialize<T>(string jsonText)
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

                if (!string.IsNullOrEmpty(prop.GetDescription()))
                    form.Add(prop.GetDescription(), currentField.ToString());
                else
                    form.Add(prop.Name, currentField.ToString());
            }

            return form;
        }

        #endregion
    }
}
