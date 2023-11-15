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
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace emenu2.Application.Services
{
    [Authorize("Product_Management")]
    public class ProductGeneralService : CrudAppService<Product, ProductDto, Guid, FilterPagedProductDto, CreateUpdateProductDto>
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IDataFilter _dataFilter;

        public ProductGeneralService(
            IRepository<Product, Guid> productRepository,
            IDataFilter dataFilter) : base(productRepository)
        {
            _productRepository = productRepository;
            _dataFilter = dataFilter;
        }

        public async Task<long> GetProductCountAsync()
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                return await _productRepository.GetCountAsync();
            }
        }

        public override Task<PagedResultDto<ProductDto>> GetListAsync(FilterPagedProductDto input)
        {
            using (_dataFilter.Disable<IMultiTenant>())
            {
                return base.GetListAsync(input);
            }
            
        }
    }
}
