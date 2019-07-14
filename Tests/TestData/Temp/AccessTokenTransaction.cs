using Newtonsoft.Json;
using RESTy.Transaction;
using RESTy.Transaction.Attributes;

namespace Tests.TestData.Temp
{
    public class AccessTokenRequest : RESTFulRequest
    {
        [Required]
        [Description("scope")]
        public string ApiScope { get; set; }

        [Required]
        [Description("grant_type")]
        public string GrantType { get; set; }

        [Required]
        [Description("client_secret")]
        public string ClientSecret { get; set; }

        [Required]
        [Description("client_id")]
        public string ClientId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }


        public AccessTokenRequest()
        {
            this.AcceptType = AcceptType.Form;
        }
    }

    public class AccessTokenResponse : RESTFulResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public AccessTokenResponse()
        {
            this.ContentType = ContentType.Json;
        }

    }
}
