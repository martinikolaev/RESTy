using Newtonsoft.Json.Linq;
using RESTy.Common.Extensions;
using RESTy.Common.Helpers;
using RESTy.Common.Interfaces;
using System;
using System.Reflection;

namespace RESTy.Common.Content
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

            if (IsJsonArray(content))
            {
                instance = this.ProcessJsonArray(JArray.Parse(content), instance);
            }
            else
            {
                instance = this.ProcessJsonObject(JObject.Parse(content), instance);
            }


            return instance;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deserializes JsonArray into an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="jArray"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private T ProcessJsonArray(JArray jArray, T obj)
        {
            if (jArray == null) return obj;

            var properties = Reflection.GetProperties(obj);

            foreach (var property in properties)
            {
                //If has JsonPath attribute available
                if (property.HasJsonPathAttribute())
                {
                    var jsonMap = property.GetJsonPath();

                    var jToken = jArray.SelectToken(jsonMap);

                    if (jToken != null)
                    {
                        this.AssignValue(obj, property, jToken);
                    }
                }
                //If has JsonProperty attribute
                else if (property.HasJsonAttribute())
                {
                    var jsonPropName = property.GetJsonPropertyName();

                    var jValue = jArray[jsonPropName];

                    if (jValue != null)
                    {
                        this.AssignValue(obj, property, jValue);
                    }
                }
                //If has no attribute
                else
                {
                    var propertyName = property.Name;
                    var jValue = jArray[propertyName];

                    if (jValue != null)
                    {
                        this.AssignValue(obj, property, jValue);
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// Deserializes JsonObject into an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private T ProcessJsonObject(JObject jObject, T obj)
        {
            if (jObject == null) return obj;

            var properties = Reflection.GetProperties(obj);

            foreach (var property in properties)
            {
                //If has JsonPath attribute available
                if (property.HasJsonPathAttribute())
                {
                    var jsonMap = property.GetJsonPath();

                    var jToken = jObject.SelectToken(jsonMap);

                    if (jToken != null)
                    {
                        this.AssignValue(obj, property, jToken);
                    }
                }
                //If has JsonProperty attribute
                else if (property.HasJsonAttribute())
                {
                    var jsonPropName = property.GetJsonPropertyName();

                    var jValue = jObject[jsonPropName];

                    if (jValue != null)
                    {
                        this.AssignValue(obj, property, jValue);
                    }
                }
                //If has no attribute
                else
                {
                    var propertyName = property.Name;
                    var jValue = jObject[propertyName];

                    if (jValue != null)
                    {
                        this.AssignValue(obj, property, jValue);
                    }
                }
            }

            return obj;
        }

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

        /// <summary>
        /// Cheks if the provided Json is JObject or JArray.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static bool IsJsonArray(string json)
        {
            var token = JToken.Parse(json);

            if (token is JArray)
                return true;
            else if (token is JObject)
                return false;
            else
                throw new InvalidOperationException("The content is not JArray nor JObject");
        }

        #endregion
    }
}
