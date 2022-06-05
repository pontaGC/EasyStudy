using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Display(Name="名前")]
        [Required]
        public string Comment { get; set; }

        [Display(Name="投稿者")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        // Tips
        // PersionIdではなく、別のプロパティ(ここではPersonKey)に値を保存したい場合、
        // ナビゲーションプロパティであるPersonにForeignKey属性を付けることで、PersonKeyを外部キーとして認識する
        //
        //    public int PersonKey { get; set; }
        //
        //    [ForeignKey(nameof(PersonKey))]
        //    public Person Person { get; set; }
    }
}
