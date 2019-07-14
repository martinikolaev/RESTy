using RESTy.Transaction.Extensions;
using RESTy.Transaction.Helpers;
using RESTy.Transaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Transaction.Content
{
    internal class XmlContentReader<T> : IContentReader<T> where T : IRESTfulResponse, new()
    {

        public string Content { get; set; }

        #region Public Methods

        public T ProcessContent(string content)
        {
            if (string.IsNullOrEmpty(content)) return default(T);

            var instance = new T();

            this.Content = content;

            return this.ProcessXml(content, instance);
        }

        public T ProcessXml(string content, T obj)
        {
            var properties = Reflection.GetProperties(obj);


            foreach(var property in properties)
            {
                if (property.HasXpathAttribute())
                {
                    var xpath = property.GetXPath();
                    if (string.IsNullOrEmpty(xpath)) break;

                    
                }
                else
                {

                }
            }

            return obj;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
