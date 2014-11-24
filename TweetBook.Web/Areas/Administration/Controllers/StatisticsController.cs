namespace TweetBook.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using Kendo.Mvc.UI;
    using OAuthTwitterWrapper;
    using System.Linq;
    using System.Web.Mvc;
    using TweetBook.Data.Repositories;
    using TweetBook.Web.Areas.Administration.ViewModels;
    using TweetBook.Web.Controllers;
    using Kendo.Mvc.Extensions;

    [Authorize(Roles = "Admin")]
    public class StatisticsController : BaseController
    {
        public StatisticsController(ITweetBookData data, IOAuthTwitterWrapper oAuthTwitterWrapper)
            : base(data, oAuthTwitterWrapper)
        {

        }

        [HttpGet]
        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Total()
        {
            var total = new TotalStatsViewModel
            {
                UsersNumber = this.Data.ApplicationUsers.All().Count(),
                UsersTweets = this.Data.Tweets.All().Where(t => t.TweetType == TweetBook.Models.TweetType.FromUser).Count(),
                FollowedTweetsNumber = this.Data.Tweets.All().Where(t => t.TweetType == TweetBook.Models.TweetType.Downloaded).Count(),
                RetweetedTweetsNumber = this.Data.Tweets.All().Where(t => t.TweetType == TweetBook.Models.TweetType.Retweeted).Count(),
                FollowedAccountsNumber = this.Data.FavouriteAccounts.All().Count()
        };

            return View(total);
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var usersDataSource = this.Data.ApplicationUsers.All()
                .ToDataSourceResult(request, user => Mapper.Map<TweetStatsViewModel>(user));

            return this.Json(usersDataSource);
        }
    }
}