using emenu2.Core.Contracts;
using emenu2.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly emenu2DbContext _context;

        public UnitOfWork(emenu2DbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
