using library_system.Core.Interfaces;
using library_system.Core.Models;
using library_system.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_system.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext Context;

        public UnitOfWork(AppDbContext _Context)
        {
            Context = _Context;

            Books = new GenericRepository<Book>(Context);
            Categories = new GenericRepository<Category>(Context);
        }

        public IGenericRepository<Book> Books { get; private set; }

        public IGenericRepository<Category> Categories { get; private set; }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
