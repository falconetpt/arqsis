using Arqsis.Model.Product;

namespace Arqsis.Infrastructure.DAL.DTO.restriction
{
    public class RestrictionWritePoco
    {
        public Product BaseProduct { set; get; }
        public Product CompatibleProduct { set; get; }
    }
}