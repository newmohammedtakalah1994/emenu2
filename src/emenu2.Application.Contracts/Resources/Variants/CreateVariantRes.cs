using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Variants
{
    public class CreateVariantRes : EntityDto
    {
      //  public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
    }
}
