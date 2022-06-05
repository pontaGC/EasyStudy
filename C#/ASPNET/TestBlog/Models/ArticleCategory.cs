using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlog.Models
{
    /// <summary>
    /// Represents the categories of the article.
    /// </summary>
    public class ArticleCategory
    {
        public int ArticleCategoryId { get; set; }

        [Required]
        [Index(IsUnique =true)]
        [StringLength(200)]
        [DisplayName("カテゴリー")]
        public string CategoryName { get; set; }

        [DisplayName("件数")]
        public int Count { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
