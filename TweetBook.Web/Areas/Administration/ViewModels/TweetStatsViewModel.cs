namespace TweetBook.Web.Areas.Administration.ViewModels
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TweetBook.Models;
    using TweetBook.Web.Infrastructure.Mapping;

    public class TweetStatsViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; } 

        public string UserName { get; set; }

        public int UserTweets { get; set; }

        public int FollowedTweetsNumber { get; set; }

        public int RetweetedTweetsNumber { get; set; }

        public int FollowedAccountsNumber { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, TweetStatsViewModel>()
                .ForMember(t => t.UserTweets, opt => opt.MapFrom(a => a.Tweets.Where(ut => ut.TweetType == TweetType.FromUser).Count()))
                .ForMember(t => t.FollowedTweetsNumber, opt => opt.MapFrom(a => a.Tweets.Where(ut => ut.TweetType == TweetType.Downloaded).Count()))
                .ForMember(t => t.RetweetedTweetsNumber, opt => opt.MapFrom(a => a.Tweets.Where(ut => ut.TweetType == TweetType.Retweeted).Count()))
               .ForMember(t => t.FollowedAccountsNumber, opt => opt.MapFrom(a => a.FavouriteAccounts.Count()))
                .ReverseMap();
        }

    }
}