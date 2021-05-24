using ToDo_List.Core;
using ToDo_List.Core.Repositories;
using ToDo_List.Persistence.Respositories;

namespace ToDo_List.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;
        public IListItemRepository ListItems { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
            ListItems = new ListItemRepository(_context);
            Users = new UserRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
