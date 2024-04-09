﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Validation.VallidationAttributes
{
    public class DatatimeValidate: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTimeOffset dateTime)
            {
                return dateTime <= DateTime.Now && dateTime >= new DateTime(1900, 01, 01);
            }
            return false;
        }
    }
}
