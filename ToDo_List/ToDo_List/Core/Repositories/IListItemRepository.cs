using System.Collections.Generic;
using ToDo_List.Core.Models;

namespace ToDo_List.Core.Repositories
{
    public interface IListItemRepository : IRepository<ListItem>
    {
        IEnumerable<ListItem> GetOverdueItems();

        IEnumerable<ListItem> GetUserItems(int userID);
    }
}
