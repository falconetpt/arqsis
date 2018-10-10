using System;
using Arqsis.Model.Category;

namespace Arqsis.Infrastructure.DAL.DTO.category
{
    public class CategoryAssembler : IBaseAssembler<CategoryReadDto, CategoryWritePoco, Category>
    {
        public CategoryReadDto ToDto(Category baseObject)
        {
            CategoryReadDto categoryReadDto = new CategoryReadDto();

            categoryReadDto.Id = baseObject.CategoryId;
            categoryReadDto.Name = baseObject.Name;

            if (baseObject.ParentCategory != null)
            {
                categoryReadDto.SuperCategoryId = baseObject.ParentCategory.CategoryId;
                categoryReadDto.SuperCategoryName = baseObject.ParentCategory.Name;
            }

            return categoryReadDto;
        }

        public Category ToDomainObject(CategoryWritePoco dto)
        {
            Category category = new Category();

            category.Name = dto.Name;
            category.ParentId = dto.SuperCategory?.CategoryId ?? Guid.Empty;
            
            return category;
        }
    }
}