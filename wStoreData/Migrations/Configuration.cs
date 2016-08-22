namespace wStoreWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wStoreData.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Entities context)
        {
            context.Authors.AddOrUpdate(x => x.Id,
                 new Author() { Id = 1, FirstName = "First", LastName ="Author" },
                 new Author() { Id = 2, FirstName = "Second", LastName = "Author" },
                 new Author() { Id = 3, FirstName = "Third", LastName = "Author" }
                 );

            context.StoreItems.AddOrUpdate(x => x.Id,
                new StoreItem()
                {
                    Id = 1,
                    Title = "Store Item 1",
                    AuthorId = 1,
                    Description = "SI1 description",
                    Created = DateTime.Now
                },
                new StoreItem()
                {
                    Id = 2,
                    Title = "Store Item 2",
                    AuthorId = 2,
                    Description = "SI2 description",
                    Created = DateTime.Now
                },
                new StoreItem()
                {
                    Id = 2,
                    Title = "Store Item 3",
                    AuthorId = 2,
                    Description = "SI3 description",
                    Created = DateTime.Now
                },
                new StoreItem()
                {
                    Id = 3,
                    Title = "Store Item 4",
                    AuthorId = 3,
                    Description = "SI4 description",
                    Created = DateTime.Now
                }
                );
        }
    }
}
