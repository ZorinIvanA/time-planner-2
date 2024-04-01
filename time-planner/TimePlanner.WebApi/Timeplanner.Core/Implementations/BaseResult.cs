using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Interfaces;

namespace Timeplanner.Core.Implementations
{
    public abstract class BaseResult<T> : IOperationResult<T>, IOperationResult
    {
        public T Result { get; protected set; }

        public bool Successful { get; protected set; }

        public string ErrorMessage { get; protected set; }

        public BaseResult(T result, bool success = true, string errorMessage = null)
        {
            if (result == null && success)
                throw new ArgumentException($"При успешном результате необходимо заполнить поле {nameof(result)}");

            this.Result = result;
            this.ErrorMessage = errorMessage;
            this.Successful = success;
        }
    }

    public abstract class BaseResult : IOperationResult
    {
        public bool Successful { get; protected set; }

        public string ErrorMessage { get; protected set; }

        public BaseResult(bool success = true, string errorMessage = null)
        {
            if (!success && string.IsNullOrEmpty(errorMessage))
                throw new ArgumentException("Если результат неуспешен - необходимо указать ошибку!");

            this.ErrorMessage = errorMessage;
            this.Successful = success;
        }
    }
}
