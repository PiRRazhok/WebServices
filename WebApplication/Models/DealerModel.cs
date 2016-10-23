using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DealerModel
    {
        public string Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }

        [Display(Name = "Cars")]
        [Required(ErrorMessage = "Required field")]
        public List<CarModel> Cars { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }
    }
}