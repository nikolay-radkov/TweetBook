namespace TweetBook.Data.Repositories
{
    using TweetBook.Data.Contracts;
    using TweetBook.Models;

    public interface ITweetBookData
    {
        ITweetBookDbContext Context { get; }

        IDeletableEntityRepository<Tweet> Tweets { get; }

        IDeletableEntityRepository<FavouriteAccount> FavouriteAccounts { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        int SaveChanges();
    }
}
