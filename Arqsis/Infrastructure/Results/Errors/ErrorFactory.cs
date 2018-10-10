using System;

namespace Arqsis.Infrastructure.Results.Errors
{
    public class ErrorFactory
    {
        public static IError CreateError(ErrorType errorType, string field)
        {
            IError error = null;

            switch (errorType)
            {
                case ErrorType.Id:
                    error = new IdError(field);
                    break;
                case ErrorType.DimensionBellowExpected:
                    error = new DimensionBellowExpectedError(field);
                    break;
                case ErrorType.DimensionMinIsHigherThanMax:
                    error = new DimensionMinIsHigherThanMaxError(field);
                    break;
            }

            return error;
        }
    }
}