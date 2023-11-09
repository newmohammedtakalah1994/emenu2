using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace emenu2.Domain.Models
{
    public class ProductImage : FullAuditedEntity<Guid>
    {
      //  public int Id { get; set; }
        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        protected ProductImage()
        {

        }
        public ProductImage(Guid id)
         : base(id)
        {

        }

    }
}
