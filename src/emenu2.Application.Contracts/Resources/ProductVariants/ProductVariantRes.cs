using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class ProductVariantRes : FullAuditedEntityDto<Guid>
    {
     //   public int Id { get; set; }
        public Guid? ProductId { get; set; }
        public ICollection<ProductDetailsRes>? ProductDetails { get; set; }
        public ICollection<ProductVariantImageRes>? ProductVariantImages { get; set; }
    }
}

