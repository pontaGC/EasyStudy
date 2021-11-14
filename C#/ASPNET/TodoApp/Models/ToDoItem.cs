using System;

namespace TodoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Summary { get; set; }

        public string Detail { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }
    }
}