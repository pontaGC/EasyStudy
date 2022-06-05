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
    /// Represents the articles in the blogs.
    /// </summary>
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        [DisplayName("タイトル")]
        public string Title { get; set; }

        [Required]
        [DisplayName("本文")]
        public string Body { get; set; }

        [DisplayName("投稿日")]
        public DateTime Created { get; set; }

        [DisplayName("更新日")]
        public DateTime Updated { get; set; }

        public virtual ArticleCategory Category { get; set; }

        public virtual ICollection<ArticleComment> Comments { get; set; }

        [NotMapped] // 画面での入力値を保持する目的のため、テーブルに登録しない
        [DisplayName("カテゴリー")]
        public string CategoryName { get; set; }
    }
}
