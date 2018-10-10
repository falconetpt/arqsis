using System;

namespace Arqsis.Infrastructure.DAL.DTO.product
{
    public class ProductReadDto
    {
        public Guid Id;
        public string Name { get; set; }
        public Guid FinishId { get; set; }
        public string FinishName { get; set; }
        public int MinHeightInMillimeters { get; set; }
        public int MinWeightInMillimeters { get; set; }
        public int MinDepthInMillimeters { get; set; }
        public int MaxHeightInMillimeters { get; set; }
        public int MaxWeightInMillimeters { get; set; }
        public int MaxDepthInMillimeters { get; set; }
    }
}