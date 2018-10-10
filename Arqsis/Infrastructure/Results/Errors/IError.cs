namespace Arqsis.Infrastructure.Results.Errors
{
    public interface IError
    {
        string FieldName { set; get; }
        string ErrorDescription { set; get; }
    }
}