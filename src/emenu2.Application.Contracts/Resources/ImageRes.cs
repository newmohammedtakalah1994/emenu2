using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;

namespace emenu2.Application.Contracts.Resources
{
    public class ImageRes : FullAuditedEntityDto<Guid>
    {

      //  public Guid? Id { get; set; }

        public string? ImageUrl { get; set; }

        //  public IRemoteStreamContent? Content { get; set; }
        //    public int Id { get; set; }

    }
}
