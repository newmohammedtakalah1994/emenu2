using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace emenu2.Domain.Models
{
    // this modle to declare variant value so value will value like red , blue , small
    public class VariantValue : FullAuditedEntity<Guid>
    {
      //  public int Id { get; set; }
        public string? ValueEn { get; set; }
        public string? ValueAr { get; set; }

        public Guid? VariantId { get; set; }
        public Variant? Variant { get; set; }
        protected VariantValue()
        {

        }
        public VariantValue(Guid id)
         : base(id)
        {

        }
    }
}
