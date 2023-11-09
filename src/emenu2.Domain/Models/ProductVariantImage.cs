using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace emenu2.Domain.Models
{
    public class ProductVariantImage : FullAuditedEntity<Guid>
    {
     //   public int Id { get; set; }
        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }
        public Guid? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }
        protected ProductVariantImage()
        {

        }
        public ProductVariantImage(Guid id)
         : base(id)
        {

        }

    }
}
