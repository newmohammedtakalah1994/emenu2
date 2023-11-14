using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Products
{
    public class ProductImageDto : FullAuditedEntityDto<Guid>
    {
     //   public int Id { get; set; }
        public Guid? ImageId { get; set; }
        public ImageDto? Image { get; set; }
        public Guid? ProductId { get; set; }
    }
}
