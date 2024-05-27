using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeplanner.Core.Implementations
{
    public class ExceptionResult<T> : BaseResult<T> where T : class
    {
        public Exception Exception { get; }

        public ExceptionResult(T element, Exception exception)
            : base(element, false, $"Исключение {exception?.Message}")
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            this.Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }
    }

    public class ExceptionResult : BaseResult
    {
        public Exception Exception { get; }

        public ExceptionResult(Exception exception)
            : base(false, $"Исключение {exception?.Message}")
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            this.Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }
    }
}
