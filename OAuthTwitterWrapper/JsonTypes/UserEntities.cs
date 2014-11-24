namespace OAuthTwitterWrapper.JsonTypes
{
    using Newtonsoft.Json;

    public class UserEntities
    {

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

}
