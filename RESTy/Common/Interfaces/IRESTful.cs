using System.Collections.Generic;

namespace RESTy.Common.Interfaces
{
    public interface IRESTful
    {
        ContentType ContentType { get; set; }
    }

    public interface IRESTfulRequest : IRESTful
    {
        #region Public Properties

        string Url { get; set; }
        List<KeyValue> CustomHeaders { get; set; }

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
