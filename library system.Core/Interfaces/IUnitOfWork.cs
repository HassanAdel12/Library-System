using library_system.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Book> Books { get; }

        IGenericRepository<Category> Categories { get; }

        int Complete();


    }
}
