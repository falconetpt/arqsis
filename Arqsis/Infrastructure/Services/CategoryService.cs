using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.category;
using Arqsis.Infrastructure.Repositories;
using Arqsis.Infrastructure.Results;
using Arqsis.Infrastructure.Results.Errors;
using Arqsis.Model.Category;

namespace Arqsis.Infrastructure.Services
{
    public class CategoryService : ICrudService<Category, CategoryReadDto, CategoryWriteDto>
    {
        private readonly CategoryRepository _repository;
        
        public CategoryService(CategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }
        
        public IEnumerable<CategoryReadDto> FindAll()
        {
            return _repository.GetAll();
        }

        public ResultWrapper<CategoryReadDto> AddElement(CategoryWriteDto finishWriteDto)
        {
            Category superCategory = _repository.GetEntityById(finishWriteDto.SuperCategoryId);

            if (finishWriteDto.SuperCategoryId != Guid.Empty && superCategory == null)
            {
                return CreateResultWrapper(null, nameof(finishWriteDto.SuperCategoryId));
            }
            
            CategoryWritePoco categoryWritePoco = new CategoryWritePoco();
            categoryWritePoco.SuperCategory = superCategory;
            categoryWritePoco.Name = finishWriteDto.Name;
            Category result = _repository.Add(categoryWritePoco);

            return CreateResultWrapper(_repository.GetById(result.CategoryId), nameof(Category.CategoryId));
        }

        public ResultWrapper<CategoryReadDto> FindOne(Guid id)
        {
            return CreateResultWrapper(_repository.GetById(id), nameof(Category.CategoryId));
        }

        public Category GetOriginalEntity(Guid id)
        {
            return _repository.GetEntityById(id);
        }

        public ResultWrapper<CategoryReadDto> UpdateElement(Guid id, CategoryWriteDto finishWriteDto)
        {
            Category superCategory = _repository.GetEntityById(finishWriteDto.SuperCategoryId);
            CategoryReadDto categoryReadDto = _repository.GetById(id);

            if (finishWriteDto.SuperCategoryId != Guid.Empty && superCategory == null)
            {
                return CreateResultWrapper(null, nameof(finishWriteDto.SuperCategoryId));
            }
            
            if (categoryReadDto == null)
            {
                return CreateResultWrapper(null, nameof(Category.CategoryId));
            }
            
            CategoryWritePoco categoryWritePoco = new CategoryWritePoco();
            categoryWritePoco.SuperCategory = superCategory;
            categoryWritePoco.Name = finishWriteDto.Name;

            return CreateResultWrapper(_repository.UpdateElement(id, categoryWritePoco), nameof(id));
        }

        public ResultWrapper<CategoryReadDto> DeleteById(Guid id)
        {
            CategoryReadDto categoryReadDto = _repository.DeleteById(id);

            return CreateResultWrapper(categoryReadDto, nameof(Category.CategoryId));
        }
        
        
        private static ResultWrapper<CategoryReadDto> CreateResultWrapper(CategoryReadDto readDto, string fieldName)
        {
            ResultWrapper<CategoryReadDto> resultWrapper = new ResultWrapper<CategoryReadDto>();

            if (readDto == null)
            {
                resultWrapper.AddError(ErrorFactory.CreateError(ErrorType.Id, fieldName));
            }

            resultWrapper.SetResult(readDto);
            return resultWrapper;
        }

    }
}