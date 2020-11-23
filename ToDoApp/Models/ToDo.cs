using System;
using System.Collections.Generic;

namespace ToDoApp.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public string UserId { get; set; }


        public virtual AspNetUsers User { get; set; }
        public ToDo() { }
        public ToDo(int Id, string UserEmail, string Name, string Description, DateTime DueDate, bool Completed)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Completed = Completed;
            
        }
    }
}
