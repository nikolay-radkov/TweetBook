namespace OAuthTwitterWrapper.JsonTypes
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Hashtag
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }

    }

}
