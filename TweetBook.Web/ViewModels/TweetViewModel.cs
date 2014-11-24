namespace TweetBook.Web.ViewModels
{
    using System;
    using TweetBook.Models;
    using TweetBook.Web.Infrastructure.Mapping;

    public class TweetViewModel
    {
        public string Message { get; set; }

        public string CreatorName { get; set; }

        public string UserName { get; set; }

    }
}