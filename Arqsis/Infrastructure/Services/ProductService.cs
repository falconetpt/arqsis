using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.DAL.DtoAndPoco.product;
using Arqsis.Infrastructure.DAL.DTO.product;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Results.Errors;
using Arqsis.Model.Dimension;
using Arqsis.Model.Finish;
using Arqsis.Model.Product;
using Arqsis.Model.Restriction;

namespace Arqsis.Infrastructure.Services
{
    public class ProductService : ICrudService<Product,ProductReadDto, ProductWriteDto>
    {
        private FinishService _finishService;
        private ProductRepository _productRepository;
        
        public ProductService(FinishService finishService, ProductRepository productRepository)
        {
            _finishService = finishService;
            _productRepository = productRepository;
        }
        
        public IEnumerable<ProductReadDto> FindAll()
        {
            return _productRepository.GetAll();
        }

        public ResultWrapper<ProductReadDto> AddElement(ProductWriteDto finishWriteDto)
        {
            ResultWrapper<ProductReadDto> resultWrapper;
            Finish finish = _finishService.GetOriginalEntity(finishWriteDto.FinishId);
            List<IError> errors = Dimension.Valid(finishWriteDto.MinHeightInMillimeters, 
                finishWriteDto.MinWeightInMillimeters, finishWriteDto.MinDepthInMillimeters,
                finishWriteDto.MaxHeightInMillimeters, finishWriteDto.MaxWeightInMillimeters, 
                finishWriteDto.MaxDepthInMillimeters);
            

            if (finish == null || errors.Count > 0)
            {
                if (finish == null)
                {
                    resultWrapper = CreateResultWrapper(null);
                }
                else
                {
                    resultWrapper = new ResultWrapper<ProductReadDto>();    
                }
                
                resultWrapper.AddError(errors);
                return resultWrapper;
            }
            
            Dimension dimension = new Dimension(finishWriteDto.MinHeightInMillimeters, 
                finishWriteDto.MinWeightInMillimeters, finishWriteDto.MinDepthInMillimeters,
                finishWriteDto.MaxHeightInMillimeters, finishWriteDto.MaxWeightInMillimeters, 
                finishWriteDto.MaxDepthInMillimeters);
            
            ProductWritePoco productWritePoco = new ProductWritePoco()
            {
                Dimension = dimension, 
                Finish = finish, 
                Name = finishWriteDto.Name
            };
            
            Product product = _productRepository.Add(productWritePoco);
            
            return CreateResultWrapper(_productRepository.GetById(product.Id));
        }

        public ResultWrapper<ProductReadDto> FindOne(Guid id)
        {
            return CreateResultWrapper(_productRepository.GetById(id));
        }

        public Product GetOriginalEntity(Guid id)
        {
            return _productRepository.GetEntityById(id);
        }

        public ResultWrapper<ProductReadDto> UpdateElement(Guid id, ProductWriteDto finishWriteDto)
        {
            ResultWrapper<ProductReadDto> resultWrapper;
            Finish finish = _finishService.GetOriginalEntity(finishWriteDto.FinishId);
            List<IError> errors = Dimension.Valid(finishWriteDto.MinHeightInMillimeters, 
                finishWriteDto.MinWeightInMillimeters, finishWriteDto.MinDepthInMillimeters,
                finishWriteDto.MaxHeightInMillimeters, finishWriteDto.MaxWeightInMillimeters, 
                finishWriteDto.MaxDepthInMillimeters);
            

            if (finish == null || errors.Count > 0)
            {
                if (finish == null)
                {
                    resultWrapper = CreateResultWrapper(null);
                }
                else
                {
                    resultWrapper = new ResultWrapper<ProductReadDto>();    
                }
                
                resultWrapper.AddError(errors);
                return resultWrapper;
            }
            
            Dimension dimension = new Dimension(finishWriteDto.MinHeightInMillimeters, 
                finishWriteDto.MinWeightInMillimeters, finishWriteDto.MinDepthInMillimeters,
                finishWriteDto.MaxHeightInMillimeters, finishWriteDto.MaxWeightInMillimeters, 
                finishWriteDto.MaxDepthInMillimeters);
            
            ProductWritePoco productWritePoco = new ProductWritePoco()
            {
                Dimension = dimension, 
                Finish = finish, 
                Name = finishWriteDto.Name
            };
            
            _productRepository.UpdateElement(id, productWritePoco);
            return CreateResultWrapper(_productRepository.GetById(id));
        }

        public ResultWrapper<ProductReadDto> DeleteById(Guid id)
        {
            ProductReadDto resultWrapper = _productRepository.GetById(id);
            _productRepository.DeleteById(id);
            return CreateResultWrapper(resultWrapper);
        }
        
        private static ResultWrapper<ProductReadDto> CreateResultWrapper(ProductReadDto finishReadDto)
        {
            ResultWrapper<ProductReadDto> resultWrapper = new ResultWrapper<ProductReadDto>();

            if (finishReadDto == null)
            {
                resultWrapper.AddError(ErrorFactory.CreateError(ErrorType.Id, nameof(Product.Id)));
            }

            resultWrapper.SetResult(finishReadDto);
            return resultWrapper;
        }

        public IEnumerable<ProductReadDto> FindByName(string name)
        {
            return _productRepository.getProductsByName(name);
        }

        public IEnumerable<ProductReadDto> GetPartsById(Guid id)
        {
            return _productRepository.getProductComponents(id);
        }

        public IEnumerable<ProductReadDto> GetParentProductsById(Guid id)
        {
            return _productRepository.getParentProducts(id);
        }

        public IEnumerable<RestrictionReadDto> GetRestrictionsByProductId(Guid id)
        {
            return _productRepository.getProductRestrictions(id);
        }
    }
}