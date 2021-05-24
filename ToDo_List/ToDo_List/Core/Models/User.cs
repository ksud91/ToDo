using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo_List.Core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }
        public ICollection<int> TaskIDs { get; set; }
        public virtual ICollection<ListItem> UserTasks { get; set; }

        public User(string forename, string surname, string username)
        {
            Forename = forename;
            Surname = surname;
            Username = username;
        }

        [Obsolete("Only needed for serialization and materialization", true)]
        public User()
        {
        }
    }
    
}
