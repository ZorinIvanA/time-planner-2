using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Interfaces;

namespace Timeplanner.Core.Implementations
{
    public class Success<T> : BaseResult<T>, IOperationResult<T>
    {
        public Success(T element) :
            base(element, true, string.Empty)
        {

        }
    }

    public class Success : BaseResult, IOperationResult
    {
        public Success() :
            base(true, string.Empty)
        {

        }
    }
}
