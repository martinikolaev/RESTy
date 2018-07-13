using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common
{
    public static class ContentReader
    {
        public static T Reader<T>(string json, T instance)            
            where T : IRESTfulResponse
        {

            //var jsonObject = JArray.Parse(json);

            var jsonObject = JObject.Parse(json);

            instance = JsonConvert.DeserializeObject<T>(json);

            //return FirstLevelCheck(jsonObject, instance);
            return instance;
        }

        public static T FirstLevelCheck<T>(JObject json, T obj) where T : new()
        {
            if (json == null || obj == null) return default(T);
            var lookDeeper = false;
            var unassignedJson = new List<JProperty>();


            foreach (var jsonProp in json.Properties())
            {
                var propInfo = PropertyLookup(jsonProp.Name, obj);
                if (propInfo != null)
                {
                    ContentReader.AssignValue(obj, propInfo, jsonProp);
                }
                else
                {
                    unassignedJson.Add(jsonProp);
                }
            }

            if (unassignedJson.Any()) lookDeeper = true;

            if (lookDeeper)
            {
                GoDeeper(unassignedJson, obj);
            }

            return obj;
        }

        public static void GoDeeper<T>(List<JProperty> jProperties, T obj)
        {
            var unassignedProperties = obj.GetType().GetProperties().Where(p => p.GetValue(obj) == null);

            foreach (var jp in jProperties)
            {
                var type = jp.Value.GetType();

            }


            foreach (var property in unassignedProperties)
            {
                var value = property.GetValue(obj);
                value.GetType().GetGenericTypeDefinition();
                //property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>);
            }

        }


        public static void AssignValue(object obj, PropertyInfo property, JProperty jsonProp)
        {
            if (property != null)
            {
                //create new object with property type
                var retrivableObject = jsonProp.Value.ToObject(property.PropertyType);

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

        public static T FindObjectToSerialize<T>(JObject json, T obj) where T : new()
        {
            var matchingProperties = 0;

            foreach (var jsonProp in json.Properties())
            {
                //retrieve the wanted property
                var property = ContentReader.PropertyLookup(jsonProp.Name, obj);



            }

            if (matchingProperties > 0) return obj;
            else return default(T);
        }


        public static void BreakObject<T>(JObject json, T instance)
           where T : RESTFulResponse
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                //if (property != null)
                //{
                //    //create new object with property type
                //    var retrivableObject = jsonProp.Value.ToObject(property.PropertyType);

                //    //if successful
                //    if (retrivableObject != null)
                //    {
                //        //Get Setter MethodInfo
                //        MethodInfo setMethodInfo = property.GetSetMethod(false);

                //        //Invoke the SetMethod to assign the new property
                //        setMethodInfo.Invoke(instance, new object[] { retrivableObject });
                //    }
                //}
            }
        }

        public static PropertyInfo PropertyLookup<T>(string propertyName, T responseObject)
        {
            foreach (var prop in ContentReader.GetProperties(responseObject))
            {
                if (prop.Name.Equals(propertyName))
                    return prop;
            }

            foreach (var prop in ContentReader.GetPropertiesWithJson(responseObject))
            {
                if (prop.GetCustomAttribute<JsonPropertyAttribute>().PropertyName.Equals(propertyName))
                    return prop;
            }

            return null;
        }

        public static JProperty ResolveJsonProperty(IEnumerable<JProperty> jsonProperties, PropertyInfo identifier)
        {
            foreach (var property in jsonProperties)
            {
                if (property.Name.Equals(identifier.Name))
                    return property;

                if (identifier.HasJsonProperty())
                {
                    if (property.Name.Equals(identifier.GetJsonProperty().PropertyName)) return property;
                }
            }

            return null;
        }

        public static PropertyInfo ResolveProperty<T>(T obj, string criteria)
        {
            return obj
                    .GetType()
                    .GetProperties()
                    .First(p =>
                    {
                        if (p.Name.Equals(criteria))
                            return true;

                        if (p.GetCustomAttribute<JsonPropertyAttribute>() != null)
                        {
                            if (p.GetCustomAttribute<JsonPropertyAttribute>().PropertyName.Equals(criteria))
                                return true;
                        }

                        return false;
                    });
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithJson<T>(T obj)
        {
            return obj
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList()
                .Where(p => p.GetCustomAttribute<JsonPropertyAttribute>() != null);
        }

        public static List<PropertyInfo> GetProperties<T>(T obj)
        {
            return obj
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        public static bool HasJsonProperty(this PropertyInfo property)
        {
            return property.GetCustomAttribute<JsonPropertyAttribute>() != null;
        }

        public static JsonPropertyAttribute GetJsonProperty(this PropertyInfo property)
        {
            return property.GetCustomAttribute<JsonPropertyAttribute>();
        }


        public static bool IsJsonArray(string json)
        {
            try
            {
                JObject.Parse(json);
            }
            catch
            {
                return true;
            }

            return false;
        }
    }
}
