using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_List.Core.Models;
using ToDo_List.Core.Repositories;

namespace ToDo_List.Persistence.Respositories
{
    public class ListItemRepository : Repository<ListItem>, IListItemRepository
    {
        public ListItemRepository(ToDoContext context) : base(context)
        {

        }

        public IEnumerable<ListItem> GetOverdueItems()
        {
            return ToDoContext.ListItems.Where(i => i.DueDate < DateTime.Now);
        }

        public IEnumerable<ListItem> GetUserItems(int userID)
        {
            return ToDoContext.ListItems.Where(i => i.UserId == userID);
        }

        public ToDoContext ToDoContext
        {
            get { return Context as ToDoContext; }
        }
    }
}
