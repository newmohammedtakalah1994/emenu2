using emenu2.Application.Contracts.Resources;
using emenu2.Application.Services;
using emenu2.Domain.Models;
using emenu2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace emenu2.Controllers;

public class ImageController : AbpController
{

    private IWebHostEnvironment _hostingEnvironment;
    private IRepository<Image, Guid> _imageRepository;
    private readonly IGuidGenerator _guidGenerator;

    public ImageController(
            IWebHostEnvironment hostingEnvironment,
            IRepository<Image, Guid> ImageRepository,
            IGuidGenerator guidGenerator

            )
    {
        _hostingEnvironment = hostingEnvironment;
        _imageRepository = ImageRepository;
        _guidGenerator = guidGenerator;
        
    }

    [HttpPost("api/app/image/upload")]

    public async Task<ActionResult> Upload(IRemoteStreamContent streamContent)
    {
        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "images/");
        Guid id = _guidGenerator.Create();
        path = path + id + ".blob";
        using (var fs = new FileStream(path, FileMode.Create))
        {
            await streamContent.GetStream().CopyToAsync(fs);
            await fs.FlushAsync();
        }
        Image image = new Image(id)
        {
            ImageUrl = path
        };
       // ImageDto  imageDto =
        Image imageResult= await _imageRepository.InsertAsync(entity: image,autoSave:true);
        ImageDto imageDto = new ImageDto
        {
            Id = imageResult.Id,
            ImageUrl = imageResult.ImageUrl

        };
       
        return Ok(imageDto);

    }

    [HttpGet("api/app/image/download")]

    public async Task<ActionResult> Download(Guid id)
    {
        string path = Path.Combine(_hostingEnvironment.ContentRootPath, "images/");
        path = path + id + ".blob";

        var fs = new FileStream(path, FileMode.OpenOrCreate);

        IRemoteStreamContent remoteStreamContent = await Task.FromResult(
            (IRemoteStreamContent)new RemoteStreamContent(fs) { }
        // {
        //     ContentType = "application/octet-stream"
        // }
        ); ;

        return Ok(remoteStreamContent);

    }

}
