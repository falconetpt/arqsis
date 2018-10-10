using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.finish;
using Arqsis.Infrastructure.DAL.DTO.product;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Services;
using Arqsis.Infrastructure.Utils;
using Arqsis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Arqsis.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ApiContext context)
        {
            var finishService = new FinishService(new FinishRepository(context));
            _service = new ProductService(finishService, new ProductRepository(context));
            
        }
         
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductReadDto>))]
        public ActionResult Get()
        {
            return Ok(_service.FindAll());
        } 
        
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductReadDto))]
        [ProducesResponseType(404)]
        public ActionResult GetById(Guid id)
        {
            ResultWrapper<ProductReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(resultWrapper.GetResult());
        }
        
        [HttpGet("nome={name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductReadDto>))]
        public ActionResult GetByName(string name)
        {
            return Ok(_service.FindByName(name));
        }
        
        [HttpGet("{id}/partes")]
        [ProducesResponseType(200, Type = typeof(ProductReadDto))]
        public ActionResult GetPartsById(Guid id)
        {
            ResultWrapper<ProductReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(_service.GetPartsById(id));
        }
        
        [HttpGet("{id}/parte_em")]
        [ProducesResponseType(200, Type = typeof(ProductReadDto))]
        public ActionResult GetParentsById(Guid id)
        {
            ResultWrapper<ProductReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(_service.GetParentProductsById(id));
        }
        
        [HttpGet("{id}/restricoes")]
        [ProducesResponseType(200, Type = typeof(RestrictionReadDto))]
        public ActionResult GetRestrictionsByProductId(Guid id)
        {
            ResultWrapper<ProductReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(_service.GetRestrictionsByProductId(id));
        }
        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductReadDto))]
        public ActionResult Post([FromBody] ProductWriteDto writeDto)
        {
            ResultWrapper<ProductReadDto> result = _service.AddElement(writeDto);
            ModelState.UpdateErrors(result.GetErrors());
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            return Created($"api/products/{result.GetResult().Id}", result.GetResult());
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Put(Guid id, [FromBody] ProductWriteDto writeDto)
        {   
            ResultWrapper<ProductReadDto> resultWrapper = _service.UpdateElement(id, writeDto);
            ModelState.UpdateErrors(resultWrapper.GetErrors());
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            return Ok(resultWrapper.GetResult());
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(Guid id)
        {
            ResultWrapper<ProductReadDto> resultWrapper = _service.DeleteById(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());
            
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            
            return NoContent();
        }
    }
}