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

namespace emenu2.Application.Services
{
    public class ProductService : CrudAppService<Product, ProductRes, Guid, FilterPagedProductDto, CreateProductRes>
    {
        public ProductService(
            IProductRepository ProductRepository
            ):base(ProductRepository)
        {
           
        }


        public override async Task<ProductRes> UpdateAsync(Guid id, CreateProductRes input)
        {
            await CheckUpdatePolicyAsync();

            if (input.NameAr == null && input.NameEn == null)
                throw new BusinessException("you can't put bothe name is null");
            var entity = await GetEntityByIdAsync(id);
            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            await MapToEntityAsync(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<ProductRes> CreateAsync(CreateProductRes input)
        {
            await CheckCreatePolicyAsync();

            var entity = await MapToEntityAsync(input);

            if (input.NameAr == null && input.NameEn == null)
                throw new BusinessException("you can't put bothe name is null");

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        protected override IQueryable<Product> ApplyDefaultSorting(IQueryable<Product> query)
        {
            return query.OrderByDescending((Product e) => e.NameEn);
        }

        public override Task<PagedResultDto<ProductRes>> GetListAsync(FilterPagedProductDto input)
        {
            return base.GetListAsync(input);
        }

        protected override Task<IQueryable<Product>> CreateFilteredQueryAsync(FilterPagedProductDto input)
        {
            IQueryable<Product> query =   Repository.GetQueryableAsync().Result;
            query = query.WhereIf(input.NameEn!=null, t => t.NameEn == input.NameEn)
                .WhereIf(input.NameAr != null, t => t.NameAr == input.NameAr);
            return  Task.FromResult(query);
           // return base.CreateFilteredQueryAsync(input);
        }

    }
}
