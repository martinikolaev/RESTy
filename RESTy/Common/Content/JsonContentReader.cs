using Newtonsoft.Json.Linq;
using RESTy.Transaction.Extensions;
using RESTy.Transaction.Helpers;
using RESTy.Transaction.Interfaces;
using System;
using System.Reflection;

namespace RESTy.Transaction.Content
{
    internal class JsonContentReader<T> : IContentReader<T> where T : IRESTfulResponse, new()
    {
        public string Content { get; set ; }

        #region Public Methods

        /// <summary>
        /// Deserialize given Json into desired class. It searches for attributes in 
        /// the following order: JsonPathAttribute, JsonPropertyAttribute, PropertyName
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public T ProcessContent(string content)
        {
            if (string.IsNullOrEmpty(content)) return default(T);

            var instance = new T();

            var jsonContent = JToken.Parse(content);
            var properties = Reflection.GetProperties(instance);

            foreach (var property in properties)
            {
                //If has JsonPath attribute available
                if (property.HasJsonPathAttribute())
                {
                    var jsonMap = property.GetJsonPath();

                    var jToken = jsonContent.SelectToken(jsonMap);

                    if (jToken != null)
                    {
                        this.AssignValue(instance, property, jToken);
                    }

                    continue;
                }

                //If has JsonProperty attribute
                else if (property.HasJsonAttribute())
                {
                    var jsonPropName = property.GetJsonPropertyName();

                    var jValue = jsonContent[jsonPropName];

                    if (jValue != null)
                    {
                        this.AssignValue(instance, property, jValue);
                    }

                    continue;
                }

                //If has no attribute
                else
                {
                    var propertyName = property.Name;
                    var jValue = jsonContent[propertyName];

                    if (jValue != null)
                    {
                        this.AssignValue(instance, property, jValue);
                    }
                }
            }

            return instance;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Instantiates and set value of variable in an object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="jToken"></param>
        private void AssignValue(object obj, PropertyInfo property, JToken jToken)
        {
            if (property == null) return;

            //create new object with property type
            var retrivableObject = jToken.ToObject(property.PropertyType);

            //if successful
            if (retrivableObject != null)
            {
                //Get Setter MethodInfo
                MethodInfo setMethodInfo = property.GetSetMethod(false);

                //Invoke the SetMethod to assign the new property
                setMethodInfo.Invoke(obj, new object[] { retrivableObject });
            }
        }
        #endregion
    }
}
