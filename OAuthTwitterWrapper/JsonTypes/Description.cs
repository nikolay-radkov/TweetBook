namespace OAuthTwitterWrapper.JsonTypes
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Description
    {		
        [JsonProperty("urls")]
		public List<Url> Urls { get; set; }
    }
}
