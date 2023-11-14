using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class CreateProductVariantImageDto : EntityDto
    {
        public Guid? ImageId { get; set; }
    }
}
