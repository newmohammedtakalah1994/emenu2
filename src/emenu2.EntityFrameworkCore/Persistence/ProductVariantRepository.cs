﻿using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
using emenu2.Domain.Helper;
using emenu2.Domain.Queries;
using emenu2.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu2.Persistence
{
    public class ProductVariantRepository : Repository, IProductVariantRepository
    {
        private readonly emenu2DbContext _context;


        public ProductVariantRepository(emenu2DbContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters)
        {
            var query = _context.ProductVariants
                        .Include(pv => pv.ProductDetails)
                        .ThenInclude(pa => pa.VariantValue)
                //  .Include(c => c.Image)
                .AsQueryable();
            query = FilterAndOrder(query, filters);

            return await query.ToListAsync();
        }


        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            return await _context.ProductVariants
                                .Include(pv => pv.ProductDetails)
                                .ThenInclude(pa => pa.VariantValue)
                             .Where(o => o.Id == id)
                            .Include(p => p.ProductVariantImages)
                                .ThenInclude(pi => pi.Image)
                            //  .Include(c => c.Image)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters,PagingParams pagingParams)
        {

            var query = _context.ProductVariants
                .Include(pv => pv.ProductDetails)
                .ThenInclude(pa => pa.VariantValue)
                        //  .Include(c => c.Image)
                        .AsQueryable();

            PagedList<ProductVariant> PagedUsers = await GetPagedListAsync(query, pagingParams.PageNumber, pagingParams.PageSize);

            query = FilterAndOrder(query, filters);

            return PagedUsers;
        }

        public void Add(ProductVariant ProductVariant)
        {
            _context.AddAsync(ProductVariant);
        }


        public void Remove(ProductVariant ProductVariant)
        {
            _context.Remove(ProductVariant);
        }

        private IQueryable<ProductVariant> FilterAndOrder(IQueryable<ProductVariant> query, ProductVariantQuery filters)
        {
            if (filters.ProductId.HasValue)
                query = query.Where(c => c.ProductId == filters.ProductId);
           
            query = GetOrderdQuery(query, filters.OrderBy, filters.IsDesc);
            return query;
        }

    }
}
