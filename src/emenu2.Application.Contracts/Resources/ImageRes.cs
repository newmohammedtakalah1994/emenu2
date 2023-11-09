using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources
{
    public class ImageRes : FullAuditedEntityDto<Guid>
    {
    //    public int Id { get; set; }
        public string? ImageUrl { get; set; }
    }
}
