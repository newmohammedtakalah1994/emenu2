using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Variants
{
    public class VariantDto : FullAuditedEntityDto<Guid>
    {

        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
    }
}

