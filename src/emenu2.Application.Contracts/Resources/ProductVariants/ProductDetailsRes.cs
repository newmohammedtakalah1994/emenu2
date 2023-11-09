using emenu2.Application.Contracts.Resources.VariantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.ProductVariants
{
    public class ProductDetailsRes: FullAuditedEntityDto<Guid>
    {
      //  public int Id { get; set; }
        public Guid? ProductVariantId { get; set; }
        public Guid? VariantValueId { get; set; }
        public VariantValueRes? VariantValue { get; set; }
    }
}
