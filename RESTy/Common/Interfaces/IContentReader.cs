namespace RESTy.Transaction.Interfaces
{
    internal interface IContentReader<T> where T : IRESTfulResponse, new()
    {
        string Content { get; set; }

        T ProcessContent(string content);
    }
}
