namespace Arqsis.Model.Dimension
{
    public interface IDimensionStrategy<TReturn>
    {
        TReturn ConvertIntoFinalDimension(int value);
    }
}