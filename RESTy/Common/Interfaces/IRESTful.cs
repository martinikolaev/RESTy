using System.Collections.Generic;

namespace RESTy.Transaction.Interfaces
{
    public interface IRESTful
    {
        ContentType ContentType { get; set; }
    }

    public interface IRESTfulRequest : IRESTful
    {
        #region Public Properties

        string Url { get; set; }
        List<KeyValue> RequestHeaders { get; set; }

        List<KeyValue> GetParameters();
        void AddGetParameter(KeyValue keyValue);



        #endregion
    }

    public interface IRESTfulResponse : IRESTful
    {
        #region Public Properties
        RESTFulResponseInternal Response { get; set; }

        #endregion

        #region Mappers

        void Map();

        #endregion
    }
}
