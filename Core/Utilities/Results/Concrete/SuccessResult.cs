﻿using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string Message) : base(true, Message)
        {
        }
        public SuccessResult() : base(true)
        {
        }
    }
}
