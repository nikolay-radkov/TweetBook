namespace TweetBook.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Newtonsoft.Json;
    using OAuthTwitterWrapper;
    using OAuthTwitterWrapper.JsonTypes;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TweetBook.Data.Repositories;
    using TweetBook.Models;
    using TweetBook.Web.ViewModels;

    public class TweetsController : BaseController
    {

        public TweetsController(ITweetBookData data, IOAuthTwitterWrapper oAuthTwitterWrapper)
            : base(data, oAuthTwitterWrapper)
        {

        }

        [HttpGet]
        public ActionResult Index(int? id, string screenName)
        {
            if (screenName == null)
            {
                return RedirectToAction("Index", "Home");
            }

            screenName = screenName.Replace(" ", "");

            string pageId = id == null ? "1" : id.ToString();

            this.TempData["page"] = int.Parse(pageId);

            this.TempData["screenName"] = screenName;

            var json = oAuthTwitterWrapper.GetTimeline(screenName, pageId);

            var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);

            return View(result);
        }


        [HttpGet]
        public ActionResult FollowTweet(TweetViewModel timeLine)
        {
            var account = this.Data.FavouriteAccounts.All()
                                 .FirstOrDefault(f => f.Name == timeLine.UserName);

            if (account == null)
            {
                account = new FavouriteAccount
                {
                    Name = timeLine.UserName
                };

                this.Data.FavouriteAccounts.Add(account);
                this.Data.SaveChanges();
            }

            var tweet = new Tweet
            {
                ApplicationUserId = this.User.Identity.GetUserId(),
                FavouriteAccountId = account.Id,
                TweetType = TweetType.Downloaded,
                Message = timeLine.Message
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Favourites");
        }

        [HttpGet]
        public ActionResult FollowAccount(string id)
        {
            var account = this.Data.FavouriteAccounts.All()
                                    .FirstOrDefault(f => f.Name == id);

            if (account == null)
            {
                account = new FavouriteAccount
                {
                    Name = id
                };

                this.Data.FavouriteAccounts.Add(account);
            }

            var userId = this.User.Identity.GetUserId();

            var user = this.Data.ApplicationUsers.All()
                                .FirstOrDefault(u => u.Id == userId);

            account.ApplicationUsers.Add(user);
            this.Data.SaveChanges();

            return RedirectToAction("Index", "Favourites");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(string tweet)
        {
            var json = oAuthTwitterWrapper.SendTweet(tweet);

            return RedirectToAction("Index", "Favourites");
        }
    }
}