using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlog.Models
{
    /// <summary>
    /// DB context for the articles.
    /// </summary>
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleComment> Comments { get; set; }

        public DbSet<ArticleCategory> Categories { get; set; }
    }
}
