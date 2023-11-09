using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu2.Domain.Contracts;
using emenu2.Domain.Models;
 
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
        public VariantValuesController(
            VariantValueService VariantValueService
          )
        {
            _VariantValueService = VariantValueService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVariantValueById(Guid id)
        {
            try
            {
                var VariantValue = await _VariantValueService.GetAsync(id);
                if (VariantValue == null)
                    return NotFound("VariantValue is not found");

                return Ok(VariantValue);


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

            await _VariantValueService.CreateAsync(resource);
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariantValue([FromRoute] Guid id)
        {
            await _VariantValueService.DeleteAsync(id);

            return Ok();
        }


    }
}