using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.finish;
using Arqsis.Infrastructure.DAL.DTO.product;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Services;
using Arqsis.Infrastructure.Utils;
using Arqsis.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Arqsis.Controllers
{
    [Route("api/finishes")]
    [ApiController]
    public class FinishesController : ControllerBase
    {
        private readonly FinishService _service;

        public FinishesController(ApiContext context)
        {
            _service = new FinishService(new FinishRepository(context));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FinishReadDto>))]
        public ActionResult Get()
        {
            return Ok(_service.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FinishReadDto))]
        [ProducesResponseType(404)]
        public ActionResult GetById(Guid id)
        {
            ResultWrapper<FinishReadDto> resultWrapper = _service.FindOne(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            return Ok(resultWrapper.GetResult());
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FinishReadDto))]
        public ActionResult Post([FromBody] FinishWriteDto finishWriteDto)
        {
            ResultWrapper<FinishReadDto> result = _service.AddElement(finishWriteDto);
            ModelState.UpdateErrors(result.GetErrors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created($"api/finishes/{result.GetResult().Id}", result.GetResult());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Put(Guid id, [FromBody] FinishWriteDto finishWriteDto)
        {
            ResultWrapper<FinishReadDto> resultWrapper = _service.UpdateElement(id, finishWriteDto);
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
            ResultWrapper<FinishReadDto> resultWrapper = _service.DeleteById(id);
            ModelState.UpdateErrors(resultWrapper.GetErrors());

            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            return NoContent();
        }
    }
}