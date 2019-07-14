using RestSharp;
using RESTy.Transaction.Attributes;
using System.Collections.Generic;

namespace RESTy.Transaction.Interfaces
{
    public interface ITransaction
    {
    }

    public interface IRESTfulRequest : ITransaction
    {
        #region Public Properties

        [Required]
        AcceptType AcceptType { get; set; }

        [Required]
        string Url { get; set; }

        List<KeyValue> RequestHeaders { get; set; }

        List<KeyValue> GetParameters();
        void AddGetParameter(KeyValue keyValue);


        #endregion
    }

    public interface IRESTfulResponse : ITransaction
    {
        #region Public Properties
        RESTFulResponseInternal Response { get; set; }

        IRestResponse InternalResponse { get; set; }

        [Required]
        ContentType ContentType { get; set; }

        #endregion

        #region Mappers

        void Map();

        #endregion
    }
}
