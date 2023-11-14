using emenu2.Application.Contracts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace emenu2.Services
{
    public interface IImageService : IApplicationService
    {
        public Task<IRemoteStreamContent> Download(Guid id, String path);
        public  Task<ImageDto> Upload(IRemoteStreamContent streamContent, String path);
    }
}
