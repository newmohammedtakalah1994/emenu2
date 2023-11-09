
namespace emenu2.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Volo.Abp.Domain.Entities.Auditing;

    public partial class Image : FullAuditedEntity<Guid>
    {

        //  public int Id { get; set; }
        public byte[]? ImageInDb { get; set; }
        public string? ImageUrl { get; set; }

        protected Image()
        {

        }
        public Image(Guid id)
         : base(id)
        {

        }

    }
   

}
