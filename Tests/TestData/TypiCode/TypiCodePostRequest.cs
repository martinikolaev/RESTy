using RESTy.Transaction;

namespace Tests.TestData.TypiCode
{
    public class TypiCodePostRequest : RESTFulRequest
    {

        #region Public Properties

        

        #endregion

        public TypiCodePostRequest(string homeUrl)
        {
            this.Url = $@"{homeUrl}/posts";
            this.AcceptType = AcceptType.Json;
        }
    }
}
