namespace RESTy.Common.Interfaces
{
    public interface IContentReader<T> where T : IRESTfulResponse, new()
    {
        string Content { get; set; }

        T ProcessContent(string content);
    }
}
