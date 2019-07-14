using RESTy.Transaction;

namespace Tests.TestData.Temp
{
    public class AccessToken
    {
        private string baseUrl { get; set; }

        public AccessToken()
        {
            this.baseUrl = "https://auth-qa2.meridiancloud.io/auth/connect/token";
        }

        public string GetAccessToken(AccessTokenRequest tokenRequest)
        {
            tokenRequest.Url = this.baseUrl;
            tokenRequest.AcceptType = AcceptType.Json;

            var response = tokenRequest.POST<AccessTokenResponse>();

            return response.AccessToken;
        }
    }
}
