using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Domain.SuccessCodes
{
    public class ElementNotFound<T> : IResult
    {
        public string Message => $"Элемент типа {typeof(T)} не найден";
    }
}
