using emenu2.Domain.Models;
using Volo.Abp.Application.Services;
using emenu2.Domain.Contracts;
using emenu2.Application.Contracts.Resources.Products;
using System;
using Volo.Abp.Domain.Repositories;
using emenu2.Application.Contracts.Resources;

namespace emenu2.Application.Services
{
    public class ImageService : CrudAppService<Image, ImageRes, Guid>
    {
        public ImageService(
            IRepository<Image,Guid> ProductRepository
            ):base(ProductRepository)
        {
           
        }





    }
}
