﻿using emenu2.Domain.Contracts;
using emenu2.Domain.Helper;
using emenu2.Domain.Models;
using emenu2.Domain.Queries;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace emenu2.Application.Services
{
    public class ProductVariantService : ApplicationService
    {
        private readonly IProductVariantRepository _ProductVariantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductVariantService(
            IProductVariantRepository ProductVariantRepository,
            IUnitOfWork unitOfWork
            )
        {
            _ProductVariantRepository = ProductVariantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters)
        {
            var list = await _ProductVariantRepository.GetProductVariantsAsync(filters);
            return list;
        }

        public async Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters, PagingParams pagingParams)
        {
            var list = await _ProductVariantRepository.GetPagedProductVariantsAsync(filters, pagingParams);
            return list;
        }

        public async Task Add(ProductVariant ProductVariant)
        {
            _ProductVariantRepository.Add(ProductVariant);
            await _unitOfWork.CompleteAsync();
         }

        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            return await _ProductVariantRepository.GetProductVariantByIdAsync(id);
        }

        public async Task RemoveProductVariant(ProductVariant ProductVariant)
        {
            _ProductVariantRepository.Remove(ProductVariant);
            await _unitOfWork.CompleteAsync();
        }


    }
}