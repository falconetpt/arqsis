using System;
using System.ComponentModel.DataAnnotations;

namespace Arqsis.Infrastructure.DAL.DTO.category
{
    public class CategoryWriteDto
    {
        [Required]
        [MaxLength(80)]
        public string Name { set; get; }
        public Guid SuperCategoryId { get; set; }
    }
}