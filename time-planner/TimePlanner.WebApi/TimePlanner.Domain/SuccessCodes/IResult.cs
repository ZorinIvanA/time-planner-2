﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlanner.Domain.SuccessCodes
{
    public interface IResult
    {
        string Message { get; }
    }
}