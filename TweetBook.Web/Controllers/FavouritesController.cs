using OAuthTwitterWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetBook.Data.Repositories;
using Microsoft.AspNet.Identity;
using AutoMapper;
using TweetBook.Web.ViewModels;

namespace TweetBook.Web.Controllers
{
    public class FavouritesController : BaseController
    {

        public FavouritesController(ITweetBookData data, IOAuthTwitterWrapper oAuthTwitterWrapper)
            : base(data, oAuthTwitterWrapper)
        {

        }

        public ActionResult Index()
        {
            var user = this.Data.ApplicationUsers.GetById(this.User.Identity.GetUserId());

            return View(user);
        }
    }
}