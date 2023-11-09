using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace emenu2.Domain.Models
{
    // this modle to declare variant attribute so name will value like color and size and matrieal
    public class Variant : FullAuditedEntity<Guid>
    {
       // public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        protected Variant()
        {

        }
        public Variant(Guid id)
         : base(id)
        {

        }
    }
}
