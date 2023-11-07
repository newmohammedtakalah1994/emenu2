using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
using emenu2.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emenu2.Application.Services;
using Volo.Abp.ObjectMapping;
using emenu2.Application.Contracts.Resources.VariantValues;
using System;

namespace emenu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantValuesController : ControllerBase
    {
        private readonly VariantValueService _VariantValueService;
        private readonly HelperService _helperService;
        private readonly IObjectMapper<emenu2ApplicationModule> _objectMapper;
        // private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VariantValuesController(
            HelperService helperService,
            VariantValueService VariantValueService,
            IObjectMapper<emenu2ApplicationModule> objectMapper,
            IUnitOfWork unitOfWork)
        {
            _helperService = helperService;
            _VariantValueService = VariantValueService;
            _objectMapper = objectMapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariantValue>>> GetVariantValues([FromQuery]VariantValuesQuery filters)
        {
            var VariantValues = await _VariantValueService.GetVariantValuesAsync(filters);

           //var results = _objectMapper.Map<IEnumerable<VariantValue>, IEnumerable<VariantValueRes>>(VariantValues);
            return Ok(VariantValues);
        }


        
        [HttpGet("paged")]
        //return VariantValues for dashboard
        public async Task<ActionResult> GetPagedVariantValuesAsync([FromQuery]VariantValuesQuery filters, [FromQuery]PagingParams pagingParams)
        {
            var VariantValues = await _VariantValueService.GetPagedVariantValuesAsync(filters, pagingParams);
            var result = _helperService.ToPageListResource<VariantValue, VariantValueRes>(VariantValues);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVariantValueById(int id)
        {
            try
            {
                var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
                if (VariantValue == null)
                    return NotFound("VariantValue is not found");

                var result = _objectMapper.Map<VariantValue, VariantValueRes>(VariantValue);


                return Ok(result);


            }
            catch (Exception e)
            {
                return Ok(e.ToString());
            
            }

        }

        
        [HttpPost]
        public async Task<ActionResult> CreateVariantValue([FromBody] CreateVariantValueRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VariantValue VariantValue = _objectMapper.Map<CreateVariantValueRes, VariantValue>(resource);

            await _VariantValueService.Add(VariantValue);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVariantValue([FromRoute] int id, [FromBody] UpdateVariantValueRes resource)
        {
            var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
            if (VariantValue == null)
                return NotFound("VariantValue is not found");

            if(resource.ValueEn == null)
            {
                resource.ValueEn = VariantValue.ValueEn;
            }


            if (resource.ValueAr == null)
            {
                resource.ValueAr = VariantValue.ValueAr;
            }


            if (resource.VariantId == null)
            {
                resource.VariantId = VariantValue.VariantId;
            }



            _objectMapper.Map(resource, VariantValue);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariantValue([FromRoute] int id)
        {
            var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
            if (VariantValue == null)
                return NotFound("VariantValue is not found");

            await _VariantValueService.RemoveVariantValue(VariantValue);

            return Ok();
        }


    }
}