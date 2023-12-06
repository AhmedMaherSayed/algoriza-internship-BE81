using Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class DiscountCodeCoupon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "IsActivated is required.")]
        public bool IsActivated { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        [InRange]
        public int? Value { get; set; }

        [Required(ErrorMessage = "Discount Type is required.")]
        [EnumDataType(typeof(DiscountType))]
        public DiscountType? DiscountType { get; set; }

        [Required(ErrorMessage = "Minimum Requests is required.")]
        [Range(0, int.MaxValue)]
        public int? MinimumRequiredBookings {  get; set; }
    }
}
