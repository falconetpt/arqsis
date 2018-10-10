using System;
using System.ComponentModel.DataAnnotations;

namespace Arqsis.Infrastructure.DAL.DTO.product
{
    public class ProductWriteDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid FinishId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MinHeightInMillimeters { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MinWeightInMillimeters { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MinDepthInMillimeters { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxHeightInMillimeters { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxWeightInMillimeters { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int MaxDepthInMillimeters { get; set; }
    }
}