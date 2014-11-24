namespace TweetBook.Web.ViewModels
{
    using TweetBook.Models;
    using TweetBook.Web.Infrastructure.Mapping;

    public class FavouriteAccountViewModel: IMapFrom<FavouriteAccount>
    {
        public string ScreenName { get; set; }
    }
}