namespace RESTy.Common
{
    public enum ContentType
    {
        [Description("application/json")]
        Json,

        [Description("xml")]
        Xml,

        [Description("application/x-www-form-urlencoded")]
        Form
    }

    public enum AcceptType
    {
        [Description("application/json")]
        Json,

        [Description("xml")]
        Xml,

        [Description("application/x-www-form-urlencoded")]
        Form
    }
}
