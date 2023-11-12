using  emenu2.Application.Contracts.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.VariantValues
{
    public class CreateVariantValueRes : EntityDto
    {
        public string? ValueEn { get; set; }
        public string? ValueAr { get; set; }

        public Guid? VariantId { get; set; }
    }
}
