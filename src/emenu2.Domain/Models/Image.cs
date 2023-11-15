
namespace emenu2.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Volo.Abp.Domain.Entities.Auditing;
    using Volo.Abp.MultiTenancy;

    public partial class Image : FullAuditedEntity<Guid>, IMultiTenant
    {

        //  public int Id { get; set; }
        public byte[]? ImageInDb { get; set; }
        public string? ImageUrl { get; set; }

        public Guid? TenantId { get; set; }

        protected Image()
        {

        }
        public Image(Guid id)
         : base(id)
        {

        }

    }
   

}
