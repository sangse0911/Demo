namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBlogs",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Blog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Blog_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Blog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryBlogs", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.CategoryBlogs", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "AccountId", "dbo.Accounts");
            DropIndex("dbo.CategoryBlogs", new[] { "Blog_Id" });
            DropIndex("dbo.CategoryBlogs", new[] { "Category_Id" });
            DropIndex("dbo.Blogs", new[] { "AccountId" });
            DropTable("dbo.CategoryBlogs");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Accounts");
        }
    }
}
