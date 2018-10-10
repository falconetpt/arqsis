using Arqsis.Model.Dimension;
using Arqsis.Model.Finish;

namespace Arqsis.Infrastructure.DAL.DtoAndPoco.product
{
    public class ProductWritePoco
    {
        public string Name { get; set; }
        public Finish Finish { get; set; }
        public Dimension Dimension { get; set; }
    }
}