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
    public class VariantService : ApplicationService
    {
        private readonly IVariantRepository _VariantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VariantService(
            IVariantRepository VariantRepository,
            IUnitOfWork unitOfWork
            )
        {
            _VariantRepository = VariantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Variant>> GetVariantsAsync(VariantsQuery filters)
        {
            var list = await _VariantRepository.GetVariantsAsync(filters);
            return list;
        }

        public async Task<PagedList<Variant>> GetPagedVariantsAsync(VariantsQuery filters, PagingParams pagingParams)
        {
            var list = await _VariantRepository.GetPagedVariantsAsync(filters, pagingParams);
            return list;
        }
        public async Task Add(Variant Variant)
        {
            _VariantRepository.Add(Variant);
            await _unitOfWork.CompleteAsync();
        ;
        }

        public async Task<Variant> GetVariantByIdAsync(int id)
        {
            return await _VariantRepository.GetVariantByIdAsync(id);
        }

        public async Task RemoveVariant(Variant Variant)
        {
            _VariantRepository.Remove(Variant);
            await _unitOfWork.CompleteAsync();
        }


    }
}