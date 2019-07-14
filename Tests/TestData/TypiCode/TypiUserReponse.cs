using RESTy.Transaction;
using RESTy.Transaction.Attributes;

namespace Tests.TestData.TypiCode
{
    public class TypiUserReponse : RESTFulResponse
    {
        [JsonPath("$")]
        public User[] Users { get; set; }

        public TypiUserReponse()
        {
            this.ContentType = ContentType.Json;
        }

    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }

}
