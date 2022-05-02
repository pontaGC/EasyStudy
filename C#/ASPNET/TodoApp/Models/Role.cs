using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        // Usersはナビゲーションプロパティと呼ばれる、外部キーに相当するプロパティ
        // virtualを付けることで、遅延ローディングを有効にしている
        // https://docs.microsoft.com/ja-jp/ef/core/querying/related-data/lazy
        public virtual ICollection<User> Users { get; set; }
    }
}