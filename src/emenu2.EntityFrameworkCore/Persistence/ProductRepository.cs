using emenu2.Domain.Models;
using emenu2.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Domain.Contracts;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace emenu2.Persistence
{
    public class ProductRepository : EfCoreRepository<emenu2DbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<emenu2DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IEnumerable<Product>> FilterByNameAsync(string name)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Set<Product>()
                .Where(p => 
                (!string.IsNullOrEmpty(p.NameEn) && p.NameEn.Contains(name)) ||
                (!string.IsNullOrEmpty(p.NameAr) && p.NameAr.Contains(name))
                )
                .ToListAsync();
        }
    }
}
