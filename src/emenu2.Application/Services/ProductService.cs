using emenu2.Domain.Models;
using Volo.Abp.Application.Services;
using emenu2.Domain.Contracts;
using emenu2.Application.Contracts.Resources.Products;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Dtos;
using System.Linq;
using Volo.Abp.Auditing;
using System.Threading.Tasks;
using Volo.Abp.Linq;
using Polly;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;

namespace emenu2.Application.Services
{
    public class ProductService : CrudAppService<Product, ProductRes, Guid, PagedAndSortedResultRequestDto, CreateProductRes>
    {
        public ProductService(
            IProductRepository ProductRepository
            ):base(ProductRepository)
        {
           
        }
        /*protected override IQueryable<Product> ApplyPaging(IQueryable<Product> query, CreateVariantValueRes input)
        {
            return base.ApplyPaging(query, input);
        }*/
        protected override IQueryable<Product> ApplyDefaultSorting(IQueryable<Product> query)
        {
            return query.OrderByDescending((Product e) => e.NameEn);
        }

        public async Task<IEnumerable<ProductRes>> GetListFilterByName(String name)
        {
            IEnumerable<Product> products = await (Repository as IProductRepository).FilterByNameAsync(name);

            IEnumerable<ProductRes> productDtos = ObjectMapper.Map<IEnumerable<Product>, IEnumerable<ProductRes>>(products);
            return productDtos;
        }
    }
}
