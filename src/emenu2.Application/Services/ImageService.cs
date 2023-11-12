using emenu2.Domain.Models;
using Volo.Abp.Application.Services;
using emenu2.Domain.Contracts;
using emenu2.Application.Contracts.Resources.Products;
using System;
using Volo.Abp.Domain.Repositories;
using emenu2.Application.Contracts.Resources;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Content;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;
using Volo.Abp.Guids;

namespace emenu2.Application.Services
{
    public class ImageService : CrudAppService<Image, ImageRes, Guid>
    {
        private readonly IGuidGenerator _guidGenerator;
        public ImageService(
            IRepository<Image,Guid> ImageRepository,
            IGuidGenerator guidGenerator
            ) :base(ImageRepository)
        {
            _guidGenerator = guidGenerator;
        }

        public Task<IRemoteStreamContent> Download(Guid id)
        {
            String path = "C:\\Users\\Admin\\source\\repos\\emenu2\\aspnet-core\\src\\emenu2.Application\\images" + id + ".blob";

            var fs = new FileStream(path, FileMode.OpenOrCreate);
            return Task.FromResult(
                (IRemoteStreamContent)new RemoteStreamContent(fs) { }
            // {
            //     ContentType = "application/octet-stream"
            // }
            ) ;
        }

        public async Task<ImageRes> Upload(IRemoteStreamContent streamContent)
        {
            
            Guid id = _guidGenerator.Create();
            String path = "C:\\Users\\Admin\\source\\repos\\emenu2\\aspnet-core\\src\\emenu2.Application\\images" + id + ".blob";
            using (var fs = new FileStream(path, FileMode.Create))
            {
                await streamContent.GetStream().CopyToAsync(fs);
                await fs.FlushAsync();
            }
            ImageRes imageRes = new ImageRes
            {
                Id = id,
                ImageUrl = path
            };
            return await CreateAsync(imageRes);
        }

    }
}
