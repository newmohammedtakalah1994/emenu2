using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu2.Application.Contracts.Resources.Products;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emenu2.Application.Services;
using Volo.Abp.ObjectMapping;
using System;
using Volo.Abp.Application.Dtos;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(
            ProductService ProductService)
        {
            _productService = ProductService;
            
        }

        [HttpGet("filter{name}")]
        public async Task<ActionResult> GetProductsFilterByName(string name)
        {
            var Product = await _productService.GetListFilterByName(name); 
            return Ok(Product);
        }


        [HttpGet("paged")]
        //return Products for dashboard
        public async Task<ActionResult> GetPagedProductsAsync([FromQuery] PagedAndSortedResultRequestDto pagingParams)
        {
            var Products = await _productService.GetListAsync(pagingParams);
           
            return Ok(Products);
        }


        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

        
            await _productService.CreateAsync(resource);

            return Ok();
        }

      
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] CreateProductRes resource)
        {
            var Product = await _productService.UpdateAsync(id, resource);
            if (Product == null)
                return NotFound("Product is not found");

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
        {
             await _productService.DeleteAsync(id);
         
            return Ok();
        }


    }
}