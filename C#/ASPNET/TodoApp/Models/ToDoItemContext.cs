using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    /// <summary>
    /// <see cref="ToDoItem"/>とデータベースをつなげる
    /// </summary>
    public class ToDoItemContext : DbContext
    {
        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}