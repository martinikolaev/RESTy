using Newtonsoft.Json.Linq;
using RESTy.Common.Extensions;
using RESTy.Common.Helpers;
using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common.Content
{
    public class JsonContentReader<T> : IContentReader<T> where T : IRESTfulResponse, new()
    {
        public string Content { get; set ; }


        /// <summary>
        /// Deserialize given Json into desired class. Checking for 
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

        private T ProcessJsonArray(JArray jObject, T obj)
        {
            if (jObject == null) return obj;

            var properties = Reflection.GetProperties(obj);

            foreach (var property in properties)
            {
                //If has JsonPath attribute available
                if (property.HasJsonMapAttribute())
                {
                    var jsonMap = property.GetJsonMap();

                    var jToken = jObject.SelectToken(jsonMap);

                    if (jToken != null)
                        this.AssignValue(obj, property, jToken);
                }
                //If has JsonProperty attribute
                else if (property.HasJsonAttribute())
                {
                    var jsonProp = property.GetJsonAttribute();

                    var jProperty = jObject[jsonProp];

                    this.AssignValue(obj, property, jProperty);

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

        private T ProcessJsonObject(JObject jObject, T obj)
        {
            if (jObject == null) return obj;

            var properties = Reflection.GetProperties(obj);

            foreach (var property in properties)
            {
                //If has JsonPath attribute available
                if (property.HasJsonMapAttribute())
                {
                    var jsonMap = property.GetJsonMap();

                    var jToken = jObject.SelectToken(jsonMap);

                    if (jToken != null)
                        this.AssignValue(obj, property, jToken);
                }
                //If has JsonProperty attribute
                else if (property.HasJsonAttribute())
                {
                    var jsonPropName = property.GetJsonAttribute();

                    var jValue = jObject[jsonPropName];

                    if(jValue != null)
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

        private void AssignValue(object obj, PropertyInfo property, JToken jToken)
        {
            if (property != null)
            {
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
        }

        private static bool IsJsonArray(string json)
        {
            var token = JToken.Parse(json);


            if (token is JArray)
                return true;
            else if (token is JObject)
                return false;

            return false;
        }

        
    }
}
