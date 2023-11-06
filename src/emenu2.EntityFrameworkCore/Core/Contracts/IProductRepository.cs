using emenu2.Core.Models.Queries;
using emenu2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Core.Models.Helper;

namespace emenu2.Core.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(ProductsQuery filters);
        Task<PagedList<Product>> GetPagedProductsAsync(ProductsQuery filters,PagingParams pagingParams);
        void Add(Product product);
        void Remove(Product product);
    }
}
