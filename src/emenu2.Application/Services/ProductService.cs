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
using emenu2.Resources.Products;
using System.Xml.Linq;
using Volo.Abp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using emenu2.Localization;

namespace emenu2.Application.Services
{
    [Authorize("Product_Management")]
    public class ProductService : CrudAppService<Product, ProductDto, Guid, FilterPagedProductDto, CreateUpdateProductDto>
    {
        private readonly IStringLocalizer<emenu2Resource> _localizer;
        public ProductService(
            IProductRepository ProductRepository,
            IStringLocalizer<emenu2Resource> localizer
            ) :base(ProductRepository)
        {
            _localizer = localizer;
        }


        [Authorize("ProductStore_Edit_Product")]
        public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
           
            if (input.NameAr.IsNullOrWhiteSpace() && input.NameEn.IsNullOrWhiteSpace())
            {
                var strExceptionNameEmpty = _localizer["exceptionNameEmpty"];
                throw new BusinessException(strExceptionNameEmpty);
            }
               
            return await base.UpdateAsync(id,input);
        }


        [Authorize("ProductStore_Create_Product")]
        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            if (input.NameAr.IsNullOrWhiteSpace() && input.NameEn.IsNullOrWhiteSpace())
            {
                var strExceptionNameEmpty = _localizer["exceptionNameEmpty"];
                throw new BusinessException(strExceptionNameEmpty);
            }

            return await base.CreateAsync(input);
        }

        [Authorize("ProductStore_Delete_Product")]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        protected override IQueryable<Product> ApplyDefaultSorting(IQueryable<Product> query)
        {
            return query.OrderByDescending((Product e) => e.NameEn);
        }

        public override Task<ProductDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(FilterPagedProductDto input)
        {
            IQueryable<Product> query =   await Repository.GetQueryableAsync();
            query = query.WhereIf(!input.NameEn.IsNullOrWhiteSpace(), t => t.NameEn == input.NameEn)
                .WhereIf(!input.NameAr.IsNullOrWhiteSpace(), t => t.NameAr == input.NameAr);

            query = await (Repository as IProductRepository).AddDetailsAsync(query);

            return query;
           // return base.CreateFilteredQueryAsync(input);
        }

    }
}
