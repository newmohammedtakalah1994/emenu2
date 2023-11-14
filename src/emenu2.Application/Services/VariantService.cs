using emenu2.Application.Contracts.Resources.Variants;
using emenu2.Domain.Models;
 
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace emenu2.Application.Services
{
    public class VariantService : CrudAppService<Variant, VariantDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateVariantDto>
    {
        public VariantService(
            IRepository<Variant, Guid> VariantRepository
            ) : base(VariantRepository)
        {

        }



    }
}
