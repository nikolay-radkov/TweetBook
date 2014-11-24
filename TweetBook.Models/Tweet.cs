namespace TweetBook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using TweetBook.Data.Contracts;

    public class Tweet : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public TweetType TweetType { get; set; }

        public int? FavouriteAccountId { get; set; }

        public virtual FavouriteAccount FavouriteAccount { get; set; }


        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
