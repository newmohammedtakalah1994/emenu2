using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace emenu2.Domain.Models
{
    // this class to define variant for specfic product
    public class ProductVariant : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        //   public int Id { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public ICollection<ProductDetails> ProductDetails { get; set; }

        public ICollection<ProductVariantImage> ProductVariantImages { get; set; }
        protected ProductVariant()
        {

        }
        public ProductVariant(Guid id)
         : base(id)
        {

        }
    }
}
