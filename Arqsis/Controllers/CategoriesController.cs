using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.category;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Services;
using Arqsis.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Arqsis.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoriesController(ApiContext context)
        {
            _service = new CategoryService(new CategoryRepository(context));
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryReadDto>))]
        public ActionResult Get()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoryReadDto))]
        [ProducesResponseType(404)]
        public ActionResult GetById(Guid id)
        {
            ResultWrapper<CategoryReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            return Ok(resultWrapper.GetResult());
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoryReadDto))]
        public ActionResult Post([FromBody] CategoryWriteDto finishWriteDto)
        {
            ResultWrapper<CategoryReadDto> result = _service.AddElement(finishWriteDto);
            ModelState.UpdateErrors(result.GetErrors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created($"api/categories/{result.GetResult().Id}", result.GetResult());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Put(Guid id, [FromBody] CategoryWriteDto finishWriteDto)
        {
            ResultWrapper<CategoryReadDto> resultWrapper = _service.UpdateElement(id, finishWriteDto);
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
            ResultWrapper<CategoryReadDto> resultWrapper = _service.DeleteById(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            return NoContent();
        }
        
    }
}