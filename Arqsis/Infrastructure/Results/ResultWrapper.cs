using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.Results.Errors;

namespace Arqsis.Infrastructure.Results
{
    public class ResultWrapper<TObject>
    {
        private TObject _result;

        private List<IError> _errors;

        public ResultWrapper()
        {
            _errors = new List<IError>();
        }
        
        public void AddError(List<IError> errorList)
        {
            errorList.ForEach(e => _errors.Add(e));
        }

        public void AddError(IError newError)
        {
            if (newError != null)
            {
                _errors.Add(newError);
            }
        }
        
        public IEnumerable<IError> GetErrors()
        {
            return new List<IError>(_errors);
        }

        public void SetResult(TObject result)
        {
            _result = result;
        }

        public TObject GetResult()
        {
            if (HasErrors())
            {
                throw new ArgumentNullException();
            }

            return _result;
        }

        private bool HasErrors()
        {
            return _errors.Count > 0;
        }
    }
}