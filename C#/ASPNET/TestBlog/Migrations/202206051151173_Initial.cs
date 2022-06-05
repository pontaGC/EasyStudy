namespace TestBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Category_ArticleCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.ArticleCategories", t => t.Category_ArticleCategoryId)
                .Index(t => t.Category_ArticleCategoryId);
            
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        ArticleCategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 200),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleCategoryId)
                .Index(t => t.CategoryName, unique: true);
            
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        ArticleCommentId = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Article_ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleCommentId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .Index(t => t.Article_ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleComments", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "Category_ArticleCategoryId", "dbo.ArticleCategories");
            DropIndex("dbo.ArticleComments", new[] { "Article_ArticleId" });
            DropIndex("dbo.ArticleCategories", new[] { "CategoryName" });
            DropIndex("dbo.Articles", new[] { "Category_ArticleCategoryId" });
            DropTable("dbo.ArticleComments");
            DropTable("dbo.ArticleCategories");
            DropTable("dbo.Articles");
        }
    }
}
