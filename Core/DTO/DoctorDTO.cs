using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DoctorDTO
    {
        public string ImagePath;
        public string FullName;
        public string Email;
        public string Phone;
        public string Gender;
        public DateTime BirthOfDate;
        public string Specialization;
        public Image? Image;
    }
}
