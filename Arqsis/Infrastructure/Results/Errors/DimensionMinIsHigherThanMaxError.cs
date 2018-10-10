namespace Arqsis.Infrastructure.Results.Errors
{
    public class DimensionMinIsHigherThanMaxError : IError
    {
        public string FieldName { get; set; }
        public string ErrorDescription { get; set; }
        
        public DimensionMinIsHigherThanMaxError(string fieldName)
        {
            FieldName = fieldName;
            ErrorDescription = "Max value cannot be below Min.";
        }
    }
}