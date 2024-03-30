using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeplanner.Core.Implementations
{
    public class Success<T> : BaseResult<T>
    {
        public Success(T element) :
            base(element, true, string.Empty)
        {

        }
    }

    public class Success : BaseResult
    {
        public Success() :
            base(true, string.Empty)
        {

        }
    }
}
