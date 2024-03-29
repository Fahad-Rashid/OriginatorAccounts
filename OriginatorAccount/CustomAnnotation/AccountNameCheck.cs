﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginatorAccount.CustomAnnotation
{
    public class AccountNameCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value.ToString() == "Initial Cash")
            {
                return new ValidationResult(ErrorMessage ?? "You cannot apply for more then two weeks");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}