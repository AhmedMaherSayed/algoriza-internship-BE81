using Core.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string? Image { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}

