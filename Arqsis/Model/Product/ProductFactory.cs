using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arqsis.Model.Product
{
    public class ProductFactory
    {
        public static Product Create()
        {
            return new Product();
        }
    }
}
