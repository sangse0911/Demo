using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Demo.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Demo.Context
{
    public class ContextModel : DbContext
    {
        public ContextModel() : base ("DemoConnection")
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.Blogs).WithMany(i => i.Categories)
        //        .Map(t => t.MapLeftKey("Category_Id")
        //            .MapRightKey("Blog_Id")
        //            .ToTable("CategoryBlogs"));
        //}
    }
}