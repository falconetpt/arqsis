using System;
using System.Collections.Generic;

namespace Arqsis.Infrastructure.DAL.DTO.category
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
        public Guid? SuperCategoryId { get; set; }
        public string SuperCategoryName { get; set; }
        
        public List<Guid?> SubCategories { get; set; }

        public void UpdateSubCategory(List<Guid?> subcategories)
        {
            SubCategories = subcategories;
        }
    }
}