namespace Arqsis.Model.Dimension
{
    public class DimensionTypeFactory
    {
        public static IDimensionStrategy Create(DimensionType type)
        {
            IDimensionStrategy result = null;
            
            switch (type)
            {
                case DimensionType.Continuous:
                    result = new DiscreteDimensionStrategy();
                    break;
                case DimensionType.Discrete:
                    result = new DiscreteDimensionStrategy();
                    break;
            }

            return result;
        }
    }
}