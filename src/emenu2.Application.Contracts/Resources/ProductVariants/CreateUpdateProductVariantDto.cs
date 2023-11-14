using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class CreateUpdateProductVariantDto : EntityDto
    {
      
        public Guid ProductId { get; set; }

        public ICollection<CreateUpdateProductDetailsDto>? ProductDetails { get; set; }

        public ICollection<CreateProductVariantImageDto>? ProductVariantImages { get; set; }
    }
}
