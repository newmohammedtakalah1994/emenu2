using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace emenu2.Application.Contracts.Resources.Products
{
    public class CreateUpdateProductImageDto : EntityDto
    {
        public Guid? ImageId { get; set; }
    }
}
