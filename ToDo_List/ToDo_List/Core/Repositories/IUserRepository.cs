using ToDo_List.Core.Models;

namespace ToDo_List.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithTasks(int userID);
    }
}
