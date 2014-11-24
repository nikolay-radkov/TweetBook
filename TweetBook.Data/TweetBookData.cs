namespace TweetBook.Data
{
    using System;
    using System.Collections.Generic;
    using TweetBook.Data.Contracts;
    using TweetBook.Data.Repositories;
    using TweetBook.Data.Repositories.Base;
    using TweetBook.Models;

    public class TweetBookData : ITweetBookData
    {
        private readonly ITweetBookDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TweetBookData(ITweetBookDbContext context)
        {
            this.context = context;
        }

        public ITweetBookDbContext Context
        {
            get
            {
                return this.context;
            }
        }


        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        public IDeletableEntityRepository<Tweet> Tweets
        {
            get { return this.GetDeletableEntityRepository<Tweet>(); }
        }

        public IDeletableEntityRepository<FavouriteAccount> FavouriteAccounts
        {
            get { return this.GetDeletableEntityRepository<FavouriteAccount>(); }
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
