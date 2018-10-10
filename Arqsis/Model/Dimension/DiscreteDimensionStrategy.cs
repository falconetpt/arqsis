namespace Arqsis.Model.Dimension
{
    public class DiscreteDimensionStrategy : IDimensionStrategy<double>
    {
        private const double ConversionFactor = 100.0;
        
        public double ConvertIntoFinalDimension(int value)
        {
            return value / ConversionFactor;
        }
    }
}