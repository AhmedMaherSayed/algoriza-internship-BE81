using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AppointmentsDTO
    {
        public decimal Price { get; set; }
        public List<Day>? days { get; set; }
    }

    public class Day
    {
        public string? day { get; set; }
        public List<string>? Times { get; set; }
    }

}
