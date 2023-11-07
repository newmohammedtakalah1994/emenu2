﻿using System.Collections.Generic;
using System.Threading.Tasks;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
using emenu2.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using emenu2.Application.Services;
using Volo.Abp.ObjectMapping;
using emenu2.Application.Contracts.Resources.Variants;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantsController : ControllerBase
    {
        private readonly VariantService _VariantService;
        private readonly HelperService _helperService;
        private readonly IObjectMapper<emenu2ApplicationModule> _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VariantsController(
            HelperService helperService,
            VariantService VariantService,
            IObjectMapper<emenu2ApplicationModule> mapper,
            IUnitOfWork unitOfWork)
        {
            _helperService = helperService;
            _VariantService = VariantService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariantRes>>> GetVariants([FromQuery]VariantsQuery filters)
        {
            var Variants = await _VariantService.GetVariantsAsync(filters);

            var results = _mapper.Map<IEnumerable<Variant>, IEnumerable<VariantRes>>(Variants);
            return Ok(results);
        }


        
        [HttpGet("paged")]
        //return Variants for dashboard
        public async Task<ActionResult> GetPagedVariantsAsync([FromQuery]VariantsQuery filters, [FromQuery]PagingParams pagingParams)
        {
            var Variants = await _VariantService.GetPagedVariantsAsync(filters, pagingParams);
            var result = _helperService.ToPageListResource<Variant, VariantRes>(Variants);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVariantById(int id)
        {
            var Variant = await _VariantService.GetVariantByIdAsync(id);
            if (Variant == null)
                return NotFound("Variant is not found");

            var result = _mapper.Map<Variant, VariantRes>(Variant);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateVariant([FromBody] CreateVariantRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Variant Variant = _mapper.Map<CreateVariantRes, Variant>(resource);

            await _VariantService.Add(Variant);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVariant([FromRoute] int id, [FromBody] UpdateVariantRes resource)
        {
            var Variant = await _VariantService.GetVariantByIdAsync(id);
            if (Variant == null)
                return NotFound("Variant is not found");

            if(resource.NameEn == null)
            {
                resource.NameEn = Variant.NameEn;
            }

            if (resource.NameEn == null)
            {
                resource.NameAr = Variant.NameAr;
            }

            _mapper.Map(resource, Variant);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariant([FromRoute] int id)
        {
            var Variant = await _VariantService.GetVariantByIdAsync(id);
            if (Variant == null)
                return NotFound("Variant is not found");

            await _VariantService.RemoveVariant(Variant);

            return Ok();
        }


    }
}