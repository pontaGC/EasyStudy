using System;
using System.ComponentModel;

namespace TodoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [DisplayName("概要")]
        public string Summary { get; set; }


        [DisplayName("詳細")]
        public string Detail { get; set; }

        [DisplayName("期限")]
        public DateTime Deadline { get; set; }

        [DisplayName("完了")]
        public bool Completed { get; set; }

        public virtual User User { get; set; }
    }
}