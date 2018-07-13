using RESTy.Common.Content;
using RESTy.Common.Interfaces;

namespace RESTy.Common
{
    public static class ContentReader
    {
        public static T Reader<T>(string content, T instance)            
            where T : IRESTfulResponse, new()
        {

            switch (instance.ContentType)
            {
                case ContentType.Json:
                    instance = new JsonContentReader<T>().ProcessContent(content);
                    break;
                case ContentType.Xml:
                    break;
                case ContentType.Form:
                    break;
            }
            
            return instance;
        }
    }
}
