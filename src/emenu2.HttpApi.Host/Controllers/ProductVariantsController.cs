﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu2.Controllers.Resources.ProductVariants;
using emenu2.Core.Contracts;
using emenu2.Core.Models;
using emenu2.Core.Models.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emenu2.Core.Services;
using emenu2.Core.Contracts;
using emenu2.Mapping;
using Volo.Abp.ObjectMapping;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly ProductVariantService _ProductVariantService;
        private readonly HelperService _helperService;
        private readonly IObjectMapper<MyModule> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductVariantsController(
            HelperService helperService,
            ProductVariantService ProductVariantService,
            IObjectMapper<MyModule> mapper,
            IUnitOfWork unitOfWork)
        {
            _helperService = helperService;
            _ProductVariantService = ProductVariantService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVariantRes>>> GetProductVariants([FromQuery]ProductVariantQuery filters)
        {
            var ProductVariants = await _ProductVariantService.GetProductVariantsAsync(filters);

            var results = _mapper.Map<IEnumerable<ProductVariant>, IEnumerable<ProductVariantRes>>(ProductVariants);
            return Ok(results);
        }


        
        [HttpGet("paged")]
        //return ProductVariants for dashboard
        public async Task<ActionResult> GetPagedProductVariantsAsync([FromQuery]ProductVariantQuery filters, [FromQuery]PagingParams pagingParams)
        {
            var ProductVariants = await _ProductVariantService.GetPagedProductVariantsAsync(filters, pagingParams);
            var result = _helperService.ToPageListResource<ProductVariant, ProductVariantRes>(ProductVariants);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductVariantById(int id)
        {
            var ProductVariant = await _ProductVariantService.GetProductVariantByIdAsync(id);
            if (ProductVariant == null)
                return NotFound("ProductVariant is not found");

            var result = _mapper.Map<ProductVariant, ProductVariantRes>(ProductVariant);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateProductVariant([FromBody] CreateProductVariantRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProductVariant ProductVariant = _mapper.Map<CreateProductVariantRes, ProductVariant>(resource);

            await _ProductVariantService.Add(ProductVariant);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductVariant([FromRoute] int id, [FromBody] UpdateProductVariantRes resource)
        {
            var ProductVariant = await _ProductVariantService.GetProductVariantByIdAsync(id);
            if (ProductVariant == null)
                return NotFound("ProductVariant is not found");

            if(resource.ProductId == null)
            {
                resource.ProductId = ProductVariant.ProductId;
            }


            _mapper.Map(resource, ProductVariant);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductVariant([FromRoute] int id)
        {
            var ProductVariant = await _ProductVariantService.GetProductVariantByIdAsync(id);
            if (ProductVariant == null)
                return NotFound("ProductVariant is not found");

            await _ProductVariantService.RemoveProductVariant(ProductVariant);

            return Ok();
        }


    }
}