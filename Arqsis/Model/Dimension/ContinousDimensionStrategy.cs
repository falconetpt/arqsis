namespace Arqsis.Model.Dimension
{
    public class ContinousDimensionStrategy : IDimensionStrategy<int>
    {
        private const double ConversionFactor = 1;
        
        public double ConvertIntoFinalDimension(string value)
        {
            if ()
            {
                
            }
            return value / ConversionFactor;
        }
    }
}