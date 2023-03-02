using Kuari.TodoApp.Core.UnitOfWork;
using Kuari.TodoApp.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoAppDbContext _context;

        public UnitOfWork(TodoAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
