using Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Booking state is required.")]
        [EnumDataType(typeof(BookingState))]
        public BookingState? BookingState { get; set; }

        [ForeignKey("FK_Bookings_AppointmentTimes_AppointmentTimeId")]
        public int? AppointmentTimeId { get; set; }
        
        [ForeignKey("FK_Bookings_Doctors_DoctorId")]
        public int? DoctorId { get; set; }
        
        [ForeignKey("FK_Bookings_AspNetUsers_PatientId")]
        public string? PatientId { get; set; }

        [ForeignKey("FK_Bookings_DiscountCodeCoupons_DiscountCodeCouponId")]
        [AllowNull]
        public int? DiscountCodeCouponId { get; set; }
    }
}
