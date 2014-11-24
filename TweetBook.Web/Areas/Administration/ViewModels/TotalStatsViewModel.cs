namespace TweetBook.Web.Areas.Administration.ViewModels
{
    public class TotalStatsViewModel
    {
        public int UsersNumber { get; set; }

        public int UsersTweets { get; set; }

        public int FollowedTweetsNumber { get; set; }

        public int RetweetedTweetsNumber { get; set; }

        public int FollowedAccountsNumber { get; set; }
    }
}