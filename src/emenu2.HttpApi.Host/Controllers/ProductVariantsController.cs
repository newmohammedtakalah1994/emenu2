using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu2.Application.Contracts.Resources.ProductVariants;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emenu2.Application.Services;
using Volo.Abp.ObjectMapping;
using System;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly ProductVariantService _ProductVariantService;
  
        public ProductVariantsController(
                ProductVariantService ProductVariantService)
            {
            _ProductVariantService = ProductVariantService;
           }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductVariantById(Guid id)
        {
            var ProductVariant = await _ProductVariantService.GetAsync(id);
            if (ProductVariant == null)
                return NotFound("ProductVariant is not found");

            return Ok(ProductVariant);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateProductVariant([FromBody] CreateProductVariantRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

     
            await _ProductVariantService.CreateAsync(resource);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductVariant([FromRoute] Guid id, [FromBody] CreateProductVariantRes resource)
        {
            var ProductVariant = await _ProductVariantService.UpdateAsync(id,resource);
          
            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductVariant([FromRoute] Guid id)
        {
             await _ProductVariantService.DeleteAsync(id);
            
            return Ok();
        }


    }
}