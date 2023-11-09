using emenu2.Application.Contracts.Resources.VariantValues;
using emenu2.Domain.Models;
using System;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace emenu2.Application.Services
{
    public class VariantValueService : CrudAppService<VariantValue, VariantValueRes, Guid, PagedAndSortedResultRequestDto, CreateVariantValueRes>
    {
        public VariantValueService(
            IRepository<VariantValue, Guid> VariantValueRepository
            ) : base(VariantValueRepository)
        {

        }
        protected override IQueryable<VariantValue> ApplyDefaultSorting(IQueryable<VariantValue> query)
        {
            return query.OrderByDescending((VariantValue e) => e.ValueEn);
        }

    }
   
}
