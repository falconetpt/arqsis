using System;
using System.Collections.Generic;
using System.Linq;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.category;
using Arqsis.Model.Category;
using Microsoft.EntityFrameworkCore;

namespace Arqsis.Infrastructure.Repositories
{
    public class CategoryRepository : IBaseRepository<Category, CategoryReadDto, CategoryWritePoco>
    {
        private readonly ApiContext _context;
        private readonly CategoryAssembler _assembler;
        
        public CategoryRepository(ApiContext context)
        {
            _context = context;
            _assembler = new CategoryAssembler();
        }
        
        public IEnumerable<CategoryReadDto> GetAll()
        {
            var result = _context.Categories
                .Include(c => c.ParentCategory)
                .Select(c => _assembler.ToDto(c))
                .ToList();

            result.ForEach(c => c.SubCategories = _context.Categories
                .Where(x => x.ParentCategory != null && x.ParentCategory.CategoryId == c.Id)
                .Select(x => x.ParentId)
                .ToList());
            
            return result;
        }

        public Category Add(CategoryWritePoco finishWriteDto)
        {
            Category category = _assembler.ToDomainObject(finishWriteDto);
            
            category = _context.Add(category).Entity;
            _context.SaveChanges();

            return category;
        }

        public CategoryReadDto GetById(Guid id)
        {
            var result = _assembler.ToDto(_context.Categories.Find(id));
            
            result.SubCategories = _context.Categories
                .Where(x => x.ParentCategory != null && x.ParentCategory.CategoryId == result.Id)
                .Select(x => x.ParentId)
                .ToList();

            return result;
        }

        public Category GetEntityById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public CategoryReadDto UpdateElement(Guid id, CategoryWritePoco finishWriteDto)
        {
            Category category = GetEntityById(id);

            if (category == null)
            {
                return null;
            }

            category.Name = finishWriteDto.Name;
            category.ParentId = finishWriteDto.SuperCategory.CategoryId;

            _context.SaveChanges();

            return GetById(id);
        }

        public CategoryReadDto DeleteById(Guid id)
        {
            Category category = GetEntityById(id);

            if (category == null)
            {
                return null;
            }

            _context.Remove(category);

            return _assembler.ToDto(category);
        }
    }
}