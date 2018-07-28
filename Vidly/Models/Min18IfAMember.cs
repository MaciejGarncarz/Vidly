using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthday is required");
            }

            var customerAge = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return customerAge >= 18 ? ValidationResult.Success : new ValidationResult("You have to be atleast 18 years old to subscribe");
        }
    }
}
