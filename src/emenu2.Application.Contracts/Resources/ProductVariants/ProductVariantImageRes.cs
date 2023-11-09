using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class ProductVariantImageRes : FullAuditedEntityDto<Guid>
    {
      //  public int Id { get; set; }
        public Guid? ImageId { get; set; }
        public ImageRes? Image { get; set; }
        public Guid? ProductId { get; set; }
    }
}
