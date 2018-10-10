using Arqsis.Infrastructure.DAL.DtoAndPoco.product;
using Arqsis.Infrastructure.DAL.DTO;
using Arqsis.Infrastructure.DAL.DTO.product;
using Arqsis.Model.Product;

namespace Arqsis.Infrastructure.DAL.DtoAndPojo.product
{
    public class ProductAssembler : IBaseAssembler<ProductReadDto, ProductWritePoco, Product>
    {
        public ProductReadDto ToDto(Product baseObject)
        {
            ProductReadDto productReadDto = new ProductReadDto();
            productReadDto.Name = baseObject.Name;
            productReadDto.Id = baseObject.Id;
            
            if (baseObject.Finish != null)
            {
                productReadDto.FinishId = baseObject.Finish.FinishId;
                productReadDto.FinishName = baseObject.Finish.Name;
            }

            if (baseObject.Dimension != null)
            {
                productReadDto.MinDepthInMillimeters = baseObject.Dimension.MinDepthInMillimeters;
                productReadDto.MinHeightInMillimeters = baseObject.Dimension.MinHeightInMillimeters;
                productReadDto.MinWeightInMillimeters = baseObject.Dimension.MinWeightInMillimeters;  
                productReadDto.MaxDepthInMillimeters = baseObject.Dimension.MaxDepthInMillimeters;
                productReadDto.MaxHeightInMillimeters = baseObject.Dimension.MaxHeightInMillimeters;
                productReadDto.MaxWeightInMillimeters = baseObject.Dimension.MaxWeightInMillimeters;
            }
            
            return productReadDto;
        }

        public Product ToDomainObject(ProductWritePoco dto)
        {
            Product product = new Product();
            
            product.Name = dto.Name;
            product.FinishId = dto.Finish.FinishId;
            product.Finish = dto.Finish;
            product.Dimension = dto.Dimension;

            return product;
        }
    }
}