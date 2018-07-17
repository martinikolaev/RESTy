using RESTy.Common.Attributes;

namespace RESTy.Common
{
    public enum ContentType
    {

        None,

        [Description("application/json")]
        Json,

        [Description("xml")]
        Xml,

        [Description("application/x-www-form-urlencoded")]
        Form
    }

    public enum AcceptType
    {
        
        None, 

        [Description("application/json")]
        Json,

        [Description("xml")]
        Xml,

        [Description("application/x-www-form-urlencoded")]
        Form
    }
}
