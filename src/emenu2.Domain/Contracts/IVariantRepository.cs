using emenu2.Domain.Queries;
using emenu2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Domain.Helper;

namespace emenu2.Domain.Contracts
{
    public interface IVariantRepository
    {
        Task<Variant> GetVariantByIdAsync(int id);
        Task<IEnumerable<Variant>> GetVariantsAsync(VariantsQuery filters);
        Task<PagedList<Variant>> GetPagedVariantsAsync(VariantsQuery filters, PagingParams pagingParams);

        void Add(Variant variant);
        void Remove(Variant variant);
    }
}
