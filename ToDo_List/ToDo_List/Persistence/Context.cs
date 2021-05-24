using System.Data.Entity;
using ToDo_List.Core.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ToDo_List.Persistence
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=SQL connection")
        {
            // Will allow the application to run and create the database if it does not exist on the specified server
            Database.SetInitializer(new DBInitializer());
            Database.Initialize(false);

        }

        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<User> Users { get; set; }

        

    }

    public class DBInitializer : CreateDatabaseIfNotExists<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            List<ListItem> items = new List<ListItem>();
            List<User> users = new List<User>();

            users.Add(new User("Kai", "Sud", "KSUD"));
            users.Add(new User("Someone", "Else", "SOMEONEELSE"));
            users.Add(new User("Someone", "Else", "SOMEONEELSE1"));
            users.Add(new User("Someone", "Else", "SOMEONEELSE2"));

            items.Add(new ListItem("example1", "description1", null, null, users.Find(x => x.Username == "KSUD")));
            items.Add(new ListItem("example2", "description1", new System.DateTime(2021,5,27), null, users.Find(x => x.Username == "KSUD")));
            items.Add(new ListItem("example3", "description1", new System.DateTime(2021, 5, 23), new System.TimeSpan(14,30,0), users.Find(x => x.Username == "KSUD")));
            items.Add(new ListItem("example4", "description1", new System.DateTime(2021, 5, 29), new System.TimeSpan(18, 17, 0), users.Find(x => x.Username == "SELSE")));
            items.Add(new ListItem("example5", "description1", new System.DateTime(2021, 5, 22), null, users.Find(x => x.Username == "SELSE1")));

            context.Users.AddRange(users);

            context.ListItems.AddRange(items);

            base.Seed(context);
        }
    }

}
