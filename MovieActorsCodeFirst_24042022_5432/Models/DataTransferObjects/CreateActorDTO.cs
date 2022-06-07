using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieActorsCodeFirst_24042022_5432.Models.DataTransferObjects
{
    public class CreateActorDTO
    {
        [Required(ErrorMessage ="bu alan zorunludur.")]
        [MinLength(3,ErrorMessage ="en az 3 karakter yazmalısnız")]
        [Display(Name ="İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "bu alan zorunludur.")]
        [MinLength(3, ErrorMessage = "en az 3 karakter yazmalısnız")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "bu alan zorunludur.")]
        [DataType(DataType.Date)]
       
        public DateTime BirthDate { get; set; }
    }
}