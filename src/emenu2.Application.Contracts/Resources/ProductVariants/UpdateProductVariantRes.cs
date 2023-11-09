using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class UpdateProductVariantRes : EntityDto<Guid>
    {
        public Guid? ProductId { get; set; }
      
    }
}
