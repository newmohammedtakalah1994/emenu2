using emenu2.Domain.Contracts;
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
    public class VariantValueRepository : Repository, IVariantValueRepository
    {
        private readonly emenu2DbContext _context;


        public VariantValueRepository(emenu2DbContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<VariantValue>> GetVariantValuesAsync(VariantValuesQuery filters)
        {
            var query = _context.VariantValues
                //  .Include(c => c.Image)
                .AsQueryable();
            query = FilterAndOrder(query, filters);

            return await query.ToListAsync();
        }


        public async Task<VariantValue> GetVariantValueByIdAsync(int id)
        {
            return await _context.VariantValues
                             .Where(o => o.Id == id)
                       //     .Include(c => c.Image)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedList<VariantValue>> GetPagedVariantValuesAsync(VariantValuesQuery filters, PagingParams pagingParams)
        {

            var query = _context.VariantValues
                     //   .Include(c => c.Image)
                        .AsQueryable();

            query = FilterAndOrder(query, filters);
            PagedList<VariantValue> PagedUsers = await GetPagedListAsync(query, pagingParams.PageNumber, pagingParams.PageSize);
           
            return PagedUsers;
        }

        public void Add(VariantValue VariantValue)
        {
            _context.AddAsync(VariantValue);
        }


        public void Remove(VariantValue VariantValue)
        {
            _context.Remove(VariantValue);
        }

        private IQueryable<VariantValue> FilterAndOrder(IQueryable<VariantValue> query, VariantValuesQuery filters)
        {

            if (filters.VariantId.HasValue)
                query = query.Where(c => c.VariantId == filters.VariantId);

            //if filter.name like arabic name or english name
            if (!string.IsNullOrWhiteSpace(filters.ValueEn))
                query = query.Where(m =>
                    EF.Functions.Like(m.ValueEn, $"%{filters.ValueEn}%")
                    );

            if (!string.IsNullOrWhiteSpace(filters.ValueAr))
                query = query.Where(m =>
                    EF.Functions.Like(m.ValueAr, $"%{filters.ValueAr}%")
                    );

            query = GetOrderdQuery(query, filters.OrderBy, filters.IsDesc);
            return query;
        }

    }
}
