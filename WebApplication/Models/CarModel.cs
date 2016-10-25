using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CarModel
    {
        [Key]
        public string Id;

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Required field")]
        public string Brand { get; set; }

        [Display(Name = "Series")]
        [Required(ErrorMessage = "Required field")]
        public string Series { get; set; }

        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "Required field")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Doors Number")]
        [Required(ErrorMessage = "Required field")]
        public int DoorNum { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Required field")]
        public string Color { get; set; }

        [Display(Name = "Body Type")]
        [Required(ErrorMessage = "Required field")]
        public string BodyType { get; set; }

        public CarModel(string id, string brand, string series, int year, int doors, string color, string type)
        {
            this.Id = id;

            this.Brand = brand;
            this.Series = series;
            this.ReleaseYear = year;

            this.DoorNum = doors;
            this.Color = color;
            this.BodyType = type;
        }
    }
}