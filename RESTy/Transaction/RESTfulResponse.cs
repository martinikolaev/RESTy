using RESTy.Transaction.Interfaces;
using System.Net;

namespace RESTy.Transaction
{
    public abstract class RESTFulResponse : IRESTfulResponse
    {
        #region Public Properties

        public RESTFulResponseInternal Response { get; set; }
        public ContentType ContentType { get; set; }

        #endregion

        #region Public Constructors

        public RESTFulResponse() { }

        #endregion

        #region Virtual Mappers

        /// <summary>
        /// Maps the content to the inherited class.
        /// </summary>
        public virtual void Map() { }

        #endregion

    }

    public class RESTFulResponseInternal
    {
        #region Public Constructors

        /// <summary>
        /// Initializes the class with the specified status code and content.
        /// </summary>
        /// <param name="statusCode">The http status code.</param>
        /// <param name="isSuccessStatusCode">A boolean value indicating if the http response was successful.</param>
        /// <param name="content">The http response content.</param>
        public RESTFulResponseInternal(HttpStatusCode statusCode, bool isSuccessStatusCode, string content)
        {
            StatusCode = statusCode;
            IsSuccessStatusCode = isSuccessStatusCode;
            Content = content;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets a value indicating if the http response was successful.
        /// </summary>
        public bool IsSuccessStatusCode { get; private set; }

        /// <summary>
        /// Gets the http response content.
        /// </summary>
        public string Content { get; private set; }

        #endregion
    }
}
