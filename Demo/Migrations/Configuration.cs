namespace Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Demo.Context;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo.Context.ContextModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Demo.Context.ContextModel context)
        {
            context.Accounts.AddOrUpdate(new Account() { UserName = "admin", PassWord = "123456" });
            
            context.Categories.AddOrUpdate(new Category() { Id = 1, Name = "adasdasdasdas" });
            context.Blogs.AddOrUpdate(a => a.Id,
                new Blog() { Id = 1, Name = "dasdase3wra", AccountId = 1 },
                new Blog() { Id = 2, Name = "sadasdasdas", AccountId = 1 }
                );
        }
    }
}
