using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Domain.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Employee Code is required")]
        [MaxLength(4,ErrorMessage = "Max length must be 4 characters")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Field Url Photo is required")]
        public string UrlPhoto { get; set; }

        [Required(ErrorMessage = "Field Email is required")]
        [EmailAddress(ErrorMessage ="The email format is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Age is required")]
        [Range(18,100,ErrorMessage = "Age must be between 18 and 100 years old")]
        public int Age { get; set; }

    }
}
