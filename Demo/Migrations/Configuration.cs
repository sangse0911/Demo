namespace Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Demo.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo.Context.ContextModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Demo.Context.ContextModel context)
        {
            context.Accounts.AddOrUpdate(new Account() { UserName = "admin", PassWord = "123456" });
            context.Authors.AddOrUpdate(a => a.Id,
                new Author() { Id = 1, Name = "aaaaaaaa", Age = 16 },
                new Author() { Id = 2, Name = "bbbbbbbb", Age = 17 }
                );
            context.Categories.AddOrUpdate( new Category() { Id = 1 , Name = "adasdasdasdas", Blogs = new List<Blog>() },
            new Category() { Id = 2, Name = "adsewrsaa", Blogs = new List<Blog>() });

            context.Blogs.AddOrUpdate(new Blog() { Name = "dasdase3wra", AuthorId = 1 },
            new  Blog() { Name = "sadasdasdas", AuthorId = 2 });
           
            context.SaveChanges();
        }
    }
}
