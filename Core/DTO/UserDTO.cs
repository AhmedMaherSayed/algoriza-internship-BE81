using Core.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class UserDTO
    {
        public IFormFile? Image { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(".+@.+\\.com", ErrorMessage= "Email is not valid")]
        public string Email { get; set; }

        [Required] 
        public string Password { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Phone number is not valid")]
        public string Phone { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public bool RememberMe {  get; set; }   

    }
}
