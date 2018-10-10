namespace Arqsis.Infrastructure.Results.Errors
{
    public class IdError : IError
    {
        public string FieldName { get; set; }
        public string ErrorDescription { get; set; }

        public IdError(string fieldName)
        {
            FieldName = fieldName;
            ErrorDescription = "Id does not exist";
        }
    }
}