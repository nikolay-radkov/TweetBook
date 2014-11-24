namespace OAuthTwitterWrapper.JsonTypes
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserMention
    {
        [JsonProperty("screenname")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }

    }

}
