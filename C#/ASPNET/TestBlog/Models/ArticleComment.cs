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
    /// Represents the commetns in the article.
    /// </summary>
    public class ArticleComment
    {
        public int ArticleCommentId { get; set; }

        [Required]
        [DisplayName("コメント")]
        public string Body { get; set; }

        [DisplayName("投稿日")]
        public DateTime Created { get; set; }

        public virtual Article Article { get; set; }

        [NotMapped] // コメントをもつ記事を特定するため
        public int ArticleId { get; set; }
    }
}
