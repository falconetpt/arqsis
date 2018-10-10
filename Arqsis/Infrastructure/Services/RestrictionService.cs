using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Results.Errors;
using Arqsis.Model.Product;
using Arqsis.Model.Restriction;

namespace Arqsis.Infrastructure.Services
{
    public class RestrictionService : ICrudService<Restriction, RestrictionReadDto, RestrictionWriteDto>
    {
        private ProductService _productService;
        private RestrictionRepository _restrictionRepository;

        public RestrictionService(ProductService productService, RestrictionRepository restrictionRepository)
        {
            _productService = productService;
            _restrictionRepository = restrictionRepository;
        }
        
        
        public IEnumerable<RestrictionReadDto> FindAll()
        {
            return _restrictionRepository.GetAll();
        }

        public ResultWrapper<RestrictionReadDto> AddElement(RestrictionWriteDto finishWriteDto)
        {
            Product baseProduct = _productService.GetOriginalEntity(finishWriteDto.BaseProductId);
            Product compatibleProduct = _productService.GetOriginalEntity(finishWriteDto.CompatibleProductId);

            if (baseProduct == null)
            {
                return CreateResultWrapper(null, nameof(finishWriteDto.BaseProductId));
            }

            if (compatibleProduct == null)
            {
                return CreateResultWrapper(null, nameof(finishWriteDto.CompatibleProductId));

            }
            
            RestrictionWritePoco restrictionWritePoco = new RestrictionWritePoco();
            restrictionWritePoco.BaseProduct = baseProduct;
            restrictionWritePoco.CompatibleProduct = compatibleProduct;

            Restriction restriction = _restrictionRepository.Add(restrictionWritePoco);

            return CreateResultWrapper(_restrictionRepository.GetById(
                restriction?.RestrictionId ?? Guid.Empty), "Restriction");

        }

        public ResultWrapper<RestrictionReadDto> FindOne(Guid id)
        {
            return CreateResultWrapper(_restrictionRepository.GetById(id), "id");
        }

        public Restriction GetOriginalEntity(Guid id)
        {
            return _restrictionRepository.GetEntityById(id);
        }

        public ResultWrapper<RestrictionReadDto> UpdateElement(Guid id, RestrictionWriteDto finishWriteDto)
        {
            throw new NotImplementedException();
        }

        public ResultWrapper<RestrictionReadDto> DeleteById(Guid id)
        {
            return CreateResultWrapper(_restrictionRepository.DeleteById(id), nameof(Restriction.RestrictionId));
        }
        
        
        private static ResultWrapper<RestrictionReadDto> CreateResultWrapper(RestrictionReadDto readDto, string fieldName)
        {
            ResultWrapper<RestrictionReadDto> resultWrapper = new ResultWrapper<RestrictionReadDto>();

            if (readDto == null)
            {
                resultWrapper.AddError(ErrorFactory.CreateError(ErrorType.Id, fieldName));
            }

            resultWrapper.SetResult(readDto);
            return resultWrapper;
        }

    }
}