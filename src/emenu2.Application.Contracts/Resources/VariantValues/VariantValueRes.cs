using emenu2.Application.Contracts.Resources.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.VariantValues
{
    public class VariantValueRes : FullAuditedEntityDto<Guid>
    {
       // public int Id { get; set; }
        public string? ValueEn { get; set; }
        public string? ValueAr { get; set; }

        public Guid? VariantId { get; set; }
        public VariantRes? Variant { get; set; }
    }
}

