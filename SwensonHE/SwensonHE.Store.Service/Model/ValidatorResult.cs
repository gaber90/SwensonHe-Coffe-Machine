﻿using SwensonHE.Store.Ground.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwensonHE.Store.Service.Model
{
    public class ValidatorResult
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public ValidationStatusEnum? Status { get; set; }
        public ValidatorResult()
        {
            IsValid = true;
            Message = string.Empty;
        }
    }
}
