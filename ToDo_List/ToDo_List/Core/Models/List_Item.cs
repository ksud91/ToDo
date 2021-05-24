using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo_List.Core.Models
{
    public class ListItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TimeSpan? DueTime { get; set; }

        public DateTime? CompletedDateTime { get; set; }
        public int? UserId { get; set; }

        public virtual User Asignee { get; set; }

        public ListItem(string title, string description, DateTime? dueDate, TimeSpan? dueTime, User user)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            DueTime = dueTime;
            UserId = user.UserId;
            Asignee = user;
        }

        public ListItem(string title, string description, DateTime? dueDate, TimeSpan? dueTime, DateTime? completedDateTime, User user)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            DueTime = dueTime;
            CompletedDateTime = completedDateTime;
            UserId = user.UserId;
            Asignee = user;
        }

        //[Obsolete("Only needed for serialization and materialization", true)]
        public ListItem()
        {
        }

    }
}
