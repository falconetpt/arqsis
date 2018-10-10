using Arqsis.Model.Category;

namespace Arqsis.Infrastructure.DAL.DTO.category
{
    public class CategoryWritePoco
    {
        public string Name { set; get; }
        public Category SuperCategory { get; set; }
    }
}