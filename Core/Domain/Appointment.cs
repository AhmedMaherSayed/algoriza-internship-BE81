using Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Core.Utilities.DayOfWeek;

namespace Core.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Day is required.")]
        [EnumDataType(typeof(DayOfWeek))]
        public DayOfWeek? DayOfWeek { get; set; }

        [ForeignKey("FK_Appointments_Doctors_DoctorId")]
        [AllowNull]
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public List<AppointmentTime>? AppointmentTimes { get; set; }
    }
}
