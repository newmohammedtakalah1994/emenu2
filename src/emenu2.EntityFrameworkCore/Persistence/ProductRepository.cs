using emenu2.Domain.Models;
using emenu2.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Domain.Contracts;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Volo.Abp.Domain.Repositories;

namespace emenu2.Persistence
{
    public class ProductRepository : EfCoreRepository<emenu2DbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<emenu2DbContext> dbContextProvider) : base(dbContextProvider)
        {
        }


        public override Task<IQueryable<Product>> WithDetailsAsync()
        {
            IQueryable<Product> query = GetQueryableAsync().Result;

            query = query.Include(p => p.ProductVariants)
                                    .ThenInclude(pv => pv.ProductDetails)
                                    .ThenInclude(pa => pa.VariantValue)
                             .Include(p => p.ProductVariants)
                                    .ThenInclude(pv => pv.ProductVariantImages)
                                    .ThenInclude(pvi => pvi.Image)
                            .Include(c => c.Image)
                             .Include(p => p.ProductImages)
                                    .ThenInclude(pi => pi.Image);
            return Task.FromResult(query);

            //return base.WithDetailsAsync();
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
