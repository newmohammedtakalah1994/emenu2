﻿using emenu2.Domain.Models;
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

namespace emenu2.Application.Services
{
    [Authorize]
    public class ProductService : CrudAppService<Product, ProductDto, Guid, FilterPagedProductDto, CreateUpdateProductDto>
    {
        public ProductService(
            IProductRepository ProductRepository
            ):base(ProductRepository)
        {
           
        }


        public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            await CheckUpdatePolicyAsync();

            if (input.NameAr.IsNullOrWhiteSpace()  && input.NameEn.IsNullOrWhiteSpace() )
                throw new BusinessException("you can't put bothe name is null");
            var entity = await GetEntityByIdAsync(id);
            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            await MapToEntityAsync(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize("ProductStore_Author_Create")]
        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {

            await CheckCreatePolicyAsync();

            var entity = await MapToEntityAsync(input);

            if (input.NameAr.IsNullOrWhiteSpace() && input.NameEn.IsNullOrWhiteSpace())
                throw new BusinessException("you can't put bothe name is null");

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        protected override IQueryable<Product> ApplyDefaultSorting(IQueryable<Product> query)
        {
            return query.OrderByDescending((Product e) => e.NameEn);
        }

        public override Task<PagedResultDto<ProductDto>> GetListAsync(FilterPagedProductDto input)
        {
            return base.GetListAsync(input);
        }

        [AllowAnonymous]
        public override Task<ProductDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(FilterPagedProductDto input)
        {
            IQueryable<Product> query =   await Repository.GetQueryableAsync();
            query = query.WhereIf(!input.NameEn.IsNullOrWhiteSpace(), t => t.NameEn == input.NameEn)
                .WhereIf(!input.NameAr.IsNullOrWhiteSpace(), t => t.NameAr == input.NameAr);
            return  query;
           // return base.CreateFilteredQueryAsync(input);
        }

    }
}
