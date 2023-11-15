using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace emenu2.Domain.Models
{
    public class Product : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        //   public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? DescEn { get; set; }
        public string? DescAr { get; set; }

        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
        protected Product()
        {

        }
        public Product(Guid id)
         : base(id)
        {

        }

    }
}
