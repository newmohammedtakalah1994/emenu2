using emenu2.Domain.Models;
using emenu2.Domain.Helper;
using emenu2.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using emenu2.Domain.Contracts;

namespace emenu2.Application.Services
{
    public class ProductService : ApplicationService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository ProductRepository,
            IUnitOfWork unitOfWork
            )
        {
            _ProductRepository = ProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ProductsQuery filters)
        {
            var list = await _ProductRepository.GetProductsAsync(filters);
            return list;
        }

        public async Task<PagedList<Product>> GetPagedProductsAsync(ProductsQuery filters, PagingParams pagingParams)
        {
            var products = await _ProductRepository.GetPagedProductsAsync(filters, pagingParams);
            return products;
        }

        public async Task Add(Product Product)
        {
            _ProductRepository.Add(Product);
            await _unitOfWork.CompleteAsync();
         
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _ProductRepository.GetProductByIdAsync(id);
        }

        public async Task RemoveProduct(Product Product)
        {
            _ProductRepository.Remove(Product);
            await _unitOfWork.CompleteAsync();
        }


    }
}
