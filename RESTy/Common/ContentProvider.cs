using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common
{
    public static class ContentProvider
    {
        #region Public Methods

        public static dynamic GetContent<T>(T obj) where T : RESTFulRequest
        {
            if (obj.ContentType == ContentType.Form)
                return GetFormContent(obj);
            else if (obj.ContentType == ContentType.Json)
                return GetJsonContent(obj);

            return null;
        }

        public static dynamic GenerateRequestObject<T>(T obj) where T : RESTFulRequest
        {
            if (obj.ContentType == ContentType.Json)
                return ContentProvider.GetJsonContent(obj);
            else if (obj.ContentType == ContentType.Form)
                return ContentProvider.GetFormContent(obj);
            //else if (obj.ContentType == ContentType.Xml)
            //{
            //    //to be continued
            //}

            throw new InvalidOperationException("Content type could not be resolved or not supported");
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

        private static string GetDescription(this PropertyInfo property)
        {
            var value = property.GetCustomAttribute<Description>()?.GetDescription();
            return value ?? string.Empty;
        }


        #endregion
    }
}
