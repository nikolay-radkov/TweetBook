namespace TweetBook.Web.Controllers
{
    using OAuthTwitterWrapper;
    using System.Web.Mvc;
    using TweetBook.Data.Repositories;
    using TweetBook.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(ITweetBookData data, IOAuthTwitterWrapper oAuthTwitterWrapper)
        {
            this.Data = data;
            this.oAuthTwitterWrapper = oAuthTwitterWrapper;
        }

        protected readonly IOAuthTwitterWrapper oAuthTwitterWrapper;

        protected ITweetBookData Data { get; set; }

        protected ApplicationUser CurrentUser { get; set; }
    }
}