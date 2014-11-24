namespace TweetBook.Web.ViewModels
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using TweetBook.Models;
    using TweetBook.Web.Infrastructure.Mapping;

    public class FavouritesViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {

        public ICollection<string> ScreenName { get; set; }

        public ICollection<TweetViewModel> Tweets { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, FavouritesViewModel>()
               .ForMember(u => u.ScreenName, opt => opt.MapFrom(a => a.FavouriteAccounts.Select(f => f.Name)))
               .ForMember(u => u.Tweets, opt => opt.MapFrom(a => a.FavouriteAccounts.Select(f => f.Tweets.Select(x => x))))
               
               .ReverseMap();
        }
    }
}