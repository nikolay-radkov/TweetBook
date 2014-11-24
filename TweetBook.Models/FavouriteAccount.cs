namespace TweetBook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TweetBook.Data.Contracts;

    public class FavouriteAccount : DeletableEntity
    {
        private ICollection<ApplicationUser> applicationUsers;
        private ICollection<Tweet> tweets;

        public FavouriteAccount()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
            this.Tweets = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers
        {

            get
            {
                return this.applicationUsers;          
            }

            set
            {
                this.applicationUsers = value;
            }
        }

        public virtual ICollection<Tweet> Tweets
        {

            get
            {
                return this.tweets;
            }

            set
            {
                this.tweets = value;
            }
        }
    }
}
