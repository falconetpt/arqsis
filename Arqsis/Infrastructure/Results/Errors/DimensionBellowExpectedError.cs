namespace Arqsis.Infrastructure.Results.Errors
{
    public class DimensionBellowExpectedError : IError
    {
        public string FieldName { get; set; }
        public string ErrorDescription { get; set; }
        
        public DimensionBellowExpectedError(string fieldName)
        {
            FieldName = fieldName;
            ErrorDescription = "Value is bellow Expected, Must be Above 0";
        }
    }
}