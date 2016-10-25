using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.DealerServiceRef;
//using WebApplication.DealerServiceReference;

namespace WebApplication.Models
{
    public class DealerModel
    {
        [Key]
        public string Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }

        [Display(Name = "Cars")]
        [Required(ErrorMessage = "Required field")]
        public List<CarModel> Cars { get; set; }

        public DealerModel(string id, string name, string email, Car[] cars)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Cars = new List<CarModel>();
            if (cars != null)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    this.Cars.Add(new CarModel(cars[i].Id, cars[i].Brand, cars[i].Series, cars[i].ReleaseYear, cars[i].DoorNum, cars[i].Color, cars[i].BodyType));
                }
            }

        }
    }
}