using System;
using ToDo_List.Core.Repositories;

namespace ToDo_List.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IListItemRepository ListItems { get; }
        IUserRepository Users { get; }
        int Save();
    }
}
