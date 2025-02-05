using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Interfaces;

namespace Timeplanner.Core.Implementations
{
    public class ConflictResult<T> : BaseResult<T>, IOperationResult<T>
    {
        public ConflictResult(T element, string errorMessage)
            : base(element, false, errorMessage)
        {

        }
    }

    public class ConflictResult : BaseResult
    {
        public ConflictResult(string errorMessage)
            : base(false, errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = $"Элемент конфликтует с существующим состоянием БД!";
        }
    }
}
