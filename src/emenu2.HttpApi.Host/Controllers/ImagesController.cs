using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 //   [EnableCors("MyPolicy")]
    public class ImagesController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        public ImagesController(
                IWebHostEnvironment hostingEnvironment
               )
        {
            _hostingEnvironment = hostingEnvironment;
            
        }

        [HttpPost("Upload")]
        
        public async Task<ActionResult> UploadImage(IFormFile image)
        {
            string fName = image.FileName;
            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "images/" + image.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }


            //new { imageId = image1.Id  , imageUrl = image1.ImageUrl}
            return Ok();
           // return Ok();
        }
    }
}
