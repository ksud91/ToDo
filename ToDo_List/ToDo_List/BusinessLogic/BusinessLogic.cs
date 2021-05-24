using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.Persistence;
using ToDo_List.Core.Repositories;
using ToDo_List.Core.Models;
using System.Text.RegularExpressions;

namespace ToDo_List
{
    public static class BusinessLogic
    {
        public static string AddUser(string forename, string surname, IUserRepository repo)
        {
            string username;

            List<User> users = repo.Find(u => u.Forename.ToUpper() == forename.ToUpper() && u.Surname.ToUpper() == surname.ToUpper()).ToList();  
            
            if(users.FirstOrDefault() is null)
            {
                username = (forename.Substring(0, 1) + surname).ToUpper();
            }
            else if(users.Count == 1)
            {
                username = (forename.Substring(0, 1) + surname).ToUpper() + "1";
            }
            else
            {

                var n = Regex.Match(users.OrderBy(u => u.Username).Last().Username, @"\d+");
                string usernum = ((int.Parse(Regex.Match(users.OrderBy(u => u.Username).Last().Username, @"\d+").Value))+1).ToString();
                username = (forename.Substring(0, 1) + surname).ToUpper() + usernum;
            }

            repo.Add(new User(forename, surname, username));

            return username;
        }

        public static User GetUser(int userID, IUserRepository repo)
        {
            return repo.GetUserWithTasks(userID);
        }

        public static User GetUser(string username, IUserRepository repo)
        {
            return repo.Find(u => u.Username == username).FirstOrDefault();
        }

        public static IEnumerable<User> GetAllUsers(IUserRepository repo)
        {
            return repo.GetAll();
        }


        public static ListItem GetListItem(int itemID, IListItemRepository repo)
        {
            return repo.Get(itemID);
        }

        public static IEnumerable<ListItem> GetAllListItems(IListItemRepository repo)
        {
            return repo.GetAll();
        }

        public static IEnumerable<ListItem> GetOverdueListItems(IListItemRepository repo)
        {
            return repo.GetAll().Where(l => l.DueDate != null && l.DueDate < DateTime.Now);
        }

        public static void AddListItem(string title, string description, DateTime? dueDate, TimeSpan? dueTime, User user, IListItemRepository repo)
        {
            repo.Add(new ListItem(title, description, dueDate, dueTime, user));
        }

        public static void AddListItem(ListItem l, IListItemRepository repo)
        {
            repo.Add(l);
        }

        public static void RemoveListItem(ListItem item, IListItemRepository repo)
        {
            repo.Remove(item);
        }

        public static void UpdateListItem(int ItemID, ListItem item, IListItemRepository repo)
        {
            var prev = repo.Get(ItemID);

            prev.Asignee = item.Asignee;
            prev.Description = item.Description;
            prev.DueDate = item.DueDate;
            prev.DueTime = item.DueTime;
            prev.CompletedDateTime = item.CompletedDateTime;

        }




    }
}
