using emenu2.Application.Contracts.Resources.ProductVariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Products
{
    public class ProductDto : FullAuditedEntityDto<Guid>
    {
      //  public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? DescEn { get; set; }
        public string? DescAr { get; set; }

        public Guid? ImageId { get; set; }
        public ImageDto? Image { get; set; }

        public ICollection<ProductVariantResDto>? ProductVariants { get; set; }

        public ICollection<ProductImageDto>? ProductImages { get; set; }

    }
}

