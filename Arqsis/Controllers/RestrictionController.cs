using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Services;
using Arqsis.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Arqsis.Controllers
{
    [Route("api/restrictions")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly RestrictionService _service;

        public RestrictionController(ApiContext context)
        {
            var finishService = new FinishService(new FinishRepository(context));
            var productService = new ProductService(finishService, new ProductRepository(context));
            _service = new RestrictionService(productService, new RestrictionRepository(context));

        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RestrictionReadDto>))]
        public ActionResult Get()
        {
            return Ok(_service.FindAll());
        } 
        
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RestrictionReadDto))]
        [ProducesResponseType(404)]
        public ActionResult GetById(Guid id)
        {
            ResultWrapper<RestrictionReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(resultWrapper.GetResult());
        } 
        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(RestrictionReadDto))]
        public ActionResult Post([FromBody] RestrictionWriteDto writeDto)
        {
            ResultWrapper<RestrictionReadDto> result = _service.AddElement(writeDto);
            ModelState.UpdateErrors(result.GetErrors());
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            return Created($"api/products/{result.GetResult().Id}", result.GetResult());
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(Guid id)
        {
            ResultWrapper<RestrictionReadDto> resultWrapper = _service.DeleteById(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());
            
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            
            return NoContent();
        }
    }
}