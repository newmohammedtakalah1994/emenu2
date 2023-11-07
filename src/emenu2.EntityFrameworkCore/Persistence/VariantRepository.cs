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
    public class VariantRepository : Repository, IVariantRepository
    {
        private readonly emenu2DbContext _context;


        public VariantRepository(emenu2DbContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<Variant>> GetVariantsAsync(VariantsQuery filters)
        {
            var query = _context.Variants
              //  .Include(c => c.Image)
                .AsQueryable();

            query = FilterAndOrder(query, filters);

            return await query.ToListAsync();
        }


        public async Task<Variant> GetVariantByIdAsync(int id)
        {
            return await _context.Variants
                             .Where(o => o.Id == id)
                       //     .Include(c => c.Image)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Variant>> GetPagedVariantsAsync(VariantsQuery filters,PagingParams pagingParams)
        {

            var query = _context.Variants
                     //   .Include(c => c.Image)
                        .AsQueryable();

            query = FilterAndOrder(query, filters);

            PagedList<Variant> PagedVariants = await GetPagedListAsync(query, pagingParams.PageNumber, pagingParams.PageSize);

            return PagedVariants;
        }

        public void Add(Variant Variant)
        {
            _context.AddAsync(Variant);
        }


        public void Remove(Variant Variant)
        {
            _context.Remove(Variant);
        }

        private IQueryable<Variant> FilterAndOrder(IQueryable<Variant> query, VariantsQuery filters)
        {
            //if filter.name like arabic name or english name
            if (!string.IsNullOrWhiteSpace(filters.NameEn))
                query = query.Where(m =>
                    EF.Functions.Like(m.NameEn, $"%{filters.NameEn}%")
                    );

            if (!string.IsNullOrWhiteSpace(filters.NameAr))
                query = query.Where(m =>
                    EF.Functions.Like(m.NameAr, $"%{filters.NameAr}%")
                    );

            query = GetOrderdQuery(query, filters.OrderBy, filters.IsDesc);
            return query;
        }

    }
}
