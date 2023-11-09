using emenu2.Application.Contracts.Resources.ProductVariants;
using emenu2.Domain.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace emenu2.Application.Services
{
    public class ProductVariantService : CrudAppService<ProductVariant, ProductVariantRes, Guid, PagedAndSortedResultRequestDto, CreateProductVariantRes>
    {
        public ProductVariantService(
            IRepository<ProductVariant, Guid> ProductVariantRepository
            ) : base(ProductVariantRepository)
        {

        }



    }
}
