using System.Collections.Generic;
using System.Threading.Tasks;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
 
using Microsoft.AspNetCore.Mvc;
using emenu2.Application.Services;
using Volo.Abp.ObjectMapping;
using emenu2.Application.Contracts.Resources.Variants;
using System;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantsController : ControllerBase
    {
        private readonly VariantService _VariantService;
     
        public VariantsController(
            VariantService VariantService
          )
        {
            _VariantService = VariantService;
        }

     
     
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVariantById(Guid id)
        {
            var Variant = await _VariantService.GetAsync(id);
            if (Variant == null)
                return NotFound("Variant is not found");

            return Ok(Variant);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateVariant([FromBody] CreateVariantRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _VariantService.CreateAsync(resource);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVariant([FromRoute] Guid id, [FromBody] CreateVariantRes resource)
        {
            var Variant = await _VariantService.UpdateAsync(id,resource);
            
            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariant([FromRoute] Guid id)
        {
            await _VariantService.DeleteAsync(id);
            return Ok();
        }


    }
}