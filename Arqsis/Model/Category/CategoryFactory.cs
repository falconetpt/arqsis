using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arqsis.Model.Category
{
    public class CategoryFactory
    {
        public static Category Create(string Name)
        {
            Category category = new Category
            {
                Name = Name
            };
            return category;
        }
    }
}
