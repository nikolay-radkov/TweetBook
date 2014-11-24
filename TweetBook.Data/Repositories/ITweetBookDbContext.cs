namespace TweetBook.Data.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TweetBook.Models;

    public interface ITweetBookDbContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<FavouriteAccount> FavouriteAccounts { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
