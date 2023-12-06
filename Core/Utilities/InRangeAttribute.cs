using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    using Core.Domain;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InRangeAttribute : ValidationAttribute
    {
        private const int MinValueForDiscountType0 = 1;
        private const int MaxValueForDiscountType0 = 100;

        private const int MinValueForDiscountType1 = 1;
        private const int MaxValueForDiscountType1 = int.MaxValue;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Discount Value is required"); ;
            }

            var instance = validationContext.ObjectInstance;
            var typeProperty = instance.GetType().GetProperty("DiscountType");
            var discountTypeValue = (DiscountType)typeProperty.GetValue(instance);

            var currentValue = (int)value;
            var errorMessage = $"The value must be in the range ";

            if (discountTypeValue == DiscountType.Value && (currentValue < MinValueForDiscountType1 && currentValue > MaxValueForDiscountType1))
            {
                errorMessage += $"({MinValueForDiscountType1} - {MaxValueForDiscountType1})";
                return new ValidationResult(errorMessage);
            }
            else if (discountTypeValue == DiscountType.Percentage && (currentValue < MinValueForDiscountType0 || currentValue > MaxValueForDiscountType0))
            {
                errorMessage += $"({MinValueForDiscountType0} : {MaxValueForDiscountType0})";
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }

}
