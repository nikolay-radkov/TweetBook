namespace OAuthTwitterWrapper
{
    using System;

	public interface IOAuthTwitterWrapper
    {
        IAuthenticateSettings AuthenticateSettings { get; set; }
        ITimeLineSettings TimeLineSettings { get; set; }
        ISearchSettings SearchSettings { get; set; }

        string GetTimeline(string screenName, string page = "1");
        string SendTweet(string tweet);
	}
}
