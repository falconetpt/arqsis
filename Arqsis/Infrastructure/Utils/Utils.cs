using System.Collections.Generic;
using Arqsis.Infrastructure.Results.Errors;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Arqsis.Infrastructure.Utils
{
    public static class Utils
    {
        public static void UpdateErrors(this ModelStateDictionary modelState, IEnumerable<IError> result)
        {
            foreach (var error in result)
            {
                modelState.AddModelError(error.FieldName, error.ErrorDescription);
            }
        }

    }
}