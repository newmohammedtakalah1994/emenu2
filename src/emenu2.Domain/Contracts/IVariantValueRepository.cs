using emenu2.Domain.Queries;
using emenu2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Domain.Helper;

namespace emenu2.Domain.Contracts
{
    public interface IVariantValueRepository
    {
        Task<VariantValue> GetVariantValueByIdAsync(int id);
        Task<IEnumerable<VariantValue>> GetVariantValuesAsync(VariantValuesQuery filters);
        Task<PagedList<VariantValue>> GetPagedVariantValuesAsync(VariantValuesQuery filters, PagingParams pagingParams);

        void Add(VariantValue variantValue);
        void Remove(VariantValue variantValue);
    }
}
