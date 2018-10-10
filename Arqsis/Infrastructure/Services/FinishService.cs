using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.DAL.DTO.finish;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Results.Errors;
using Arqsis.Model;
using Arqsis.Model.Finish;

namespace Arqsis.Infrastructure.Services
{
    public class FinishService : ICrudService<Finish, FinishReadDto, FinishWriteDto>
    {
        private readonly FinishRepository _repository;

        public FinishService(FinishRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<FinishReadDto> FindAll()
        {
            return _repository.GetAll();
        }

        public ResultWrapper<FinishReadDto> AddElement(FinishWriteDto finishWriteDto)
        {
            Finish finish = _repository.Add(finishWriteDto);
            return CreateResultWrapper(_repository.GetById(finish.FinishId));
        }

        public ResultWrapper<FinishReadDto> FindOne(Guid id)
        {
            FinishReadDto finishReadDto = _repository.GetById(id);
            var resultWrapper = CreateResultWrapper(finishReadDto);

            return resultWrapper;
        }

        public Finish GetOriginalEntity(Guid id)
        {
            return _repository.GetEntityById(id);
        }

        public ResultWrapper<FinishReadDto> UpdateElement(Guid id, FinishWriteDto finishWriteDto)
        {
            FinishReadDto finishReadDto = _repository.UpdateElement(id, finishWriteDto);
            var resultWrapper = CreateResultWrapper(finishReadDto);

            return resultWrapper;
        }

        public ResultWrapper<FinishReadDto> DeleteById(Guid id)
        {
            FinishReadDto finishReadDto = _repository.DeleteById(id);
            var resultWrapper = CreateResultWrapper(finishReadDto);

            return resultWrapper;
        }
        
        private static ResultWrapper<FinishReadDto> CreateResultWrapper(FinishReadDto finishReadDto)
        {
            ResultWrapper<FinishReadDto> resultWrapper = new ResultWrapper<FinishReadDto>();

            if (finishReadDto == null)
            {
                resultWrapper.AddError(ErrorFactory.CreateError(ErrorType.Id, nameof(Finish.FinishId)));
            }

            resultWrapper.SetResult(finishReadDto);
            return resultWrapper;
        }

    }
}