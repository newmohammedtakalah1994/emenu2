using emenu2.Core.Models.Queries;
using emenu2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Core.Models.Helper;

namespace emenu2.Core.Contracts
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant> GetProductVariantByIdAsync(int id);
        Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters);
        Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters, PagingParams pagingParams);

        void Add(ProductVariant productVariant);
        void Remove(ProductVariant productVariant);
    }
}
