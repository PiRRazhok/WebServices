using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfServices
{
    public class Car
    {
        [Key]
        public string Id;

        public string Brand;
        public string Series;
        public int ReleaseYear;

        public int DoorNum;
        public string Color;
        public string BodyType;

        public Car()
        {
            this.Id = "";

            this.Brand = "";
            this.Series = "";
            this.ReleaseYear = 1900;

            this.DoorNum = 4;
            this.Color = "Black";
            this.BodyType = "Sedan";
        }

        public Car(string brand, string series, int year, int doors, string color, string type)
        {
            this.Brand = brand;
            this.Series = series;
            this.ReleaseYear = year;

            this.DoorNum = doors;
            this.Color = color;
            this.BodyType = type;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}