using System.Linq;
using ToDo_List.Core.Models;
using ToDo_List.Core.Repositories;
using System.Data.Entity;

namespace ToDo_List.Persistence.Respositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ToDoContext ctx) : base(ctx)
        {
        }

        public User GetUserWithTasks(int userID)
        {
            return ToDoContext.Users.Include(u => u.UserTasks).Where(u => u.UserId == userID).FirstOrDefault();
        }

        public ToDoContext ToDoContext
        {
            get { return Context as ToDoContext; }
        }
    }
}
