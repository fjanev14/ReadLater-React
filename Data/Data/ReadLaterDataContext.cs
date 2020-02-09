using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadLater.Entities;

namespace ReadLater.Data
{
    public class ReadLaterDataContext : DbContext, IDbContext
    {
        static ReadLaterDataContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ReadLaterDataContext>());
        }

        public ReadLaterDataContext()
            : base("Name=ReadLaterDataContext")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyStateChanges();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Category> categoryMap = modelBuilder.Entity<Category>();
            EntityTypeConfiguration<Bookmark> bookmarkMap = modelBuilder.Entity<Bookmark>();
            EntityTypeConfiguration<UserBookmark> userBookmarkMap = modelBuilder.Entity<UserBookmark>();
            EntityTypeConfiguration<UserFriendBookmark> UserFriendBookmarkMap = modelBuilder.Entity<UserFriendBookmark>();
            EntityTypeConfiguration<UserBookmark1> userBookmarkMap1 = modelBuilder.Entity<UserBookmark1>();
            EntityTypeConfiguration<UserFriendBookmark1> UserFriendBookmarkMap1 = modelBuilder.Entity<UserFriendBookmark1>();
        }

        public System.Data.Entity.DbSet<ReadLater.Entities.Category> Categories { get; set; }
    }
}
