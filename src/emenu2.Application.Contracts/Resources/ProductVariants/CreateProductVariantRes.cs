using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class CreateProductVariantRes : EntityDto<Guid>
    {
      
      //  public int ProductId { get; set; }

        public ICollection<CreateProductDetailsRes>? ProductDetails { get; set; }

        public ICollection<CreateProductVariantImageRes>? ProductVariantImages { get; set; }
    }
}
