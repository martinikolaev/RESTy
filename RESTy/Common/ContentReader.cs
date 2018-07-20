using RESTy.Transaction.Content;
using RESTy.Transaction.Interfaces;
using System;

namespace RESTy.Transaction
{
    internal static class ContentReader
    {
        /// <summary>
        /// Takes the provided content and deserialize it in type specified by <see cref="ContentType"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static T Reader<T>(string content, T instance)            
            where T : IRESTfulResponse, new()
        {

            switch (instance.ContentType)
            {
                case ContentType.None:
                    throw new InvalidOperationException($"The desired deserialization class has no {nameof(ContentType)}");
                case ContentType.Json:
                    instance = new JsonContentReader<T>().ProcessContent(content);
                    break;
                case ContentType.Xml:
                    instance = new XmlContentReader<T>().ProcessContent(content);
                    break;
                case ContentType.Form:
                    break;
            }
            
            return instance;
        }
    }
}
