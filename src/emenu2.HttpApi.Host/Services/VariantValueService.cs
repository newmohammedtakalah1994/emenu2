using emenu2.Core.Contracts;
using emenu2.Core.Contracts;
using emenu2.Core.Models;
using emenu2.Core.Models.Helper;
using emenu2.Core.Models.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace emenu2.Core.Services
{
    public class VariantValueService : ApplicationService
    {
        private readonly IVariantValueRepository _VariantValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VariantValueService(
            IVariantValueRepository VariantValueRepository,
            IUnitOfWork unitOfWork
            )
        {
            _VariantValueRepository = VariantValueRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VariantValue>> GetVariantValuesAsync(VariantValuesQuery filters)
        {
            var list = await _VariantValueRepository.GetVariantValuesAsync(filters);
            return list;
        }

        public async Task<PagedList<VariantValue>> GetPagedVariantValuesAsync(VariantValuesQuery filters, PagingParams pagingParams)
        {
            var list = await _VariantValueRepository.GetPagedVariantValuesAsync(filters, pagingParams);
            return list;
        }

        public async Task<IActionResult> Add(VariantValue VariantValue)
        {
            _VariantValueRepository.Add(VariantValue);
            await _unitOfWork.CompleteAsync();
            return new OkObjectResult("VariantValue AddedSuccessfully");
        }

        public async Task<VariantValue> GetVariantValueByIdAsync(int id)
        {
            return await _VariantValueRepository.GetVariantValueByIdAsync(id);
        }

        public async Task RemoveVariantValue(VariantValue VariantValue)
        {
            _VariantValueRepository.Remove(VariantValue);
            await _unitOfWork.CompleteAsync();
        }


    }
}
