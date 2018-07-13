using RESTy.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common.Interfaces
{
    public interface IContentReader<T> where T : IRESTfulResponse, new()
    {
        string Content { get; set; }

        T ProcessContent(string content);
    }
}
