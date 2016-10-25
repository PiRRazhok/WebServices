using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfServices
{
    public class Dealer
    {
        [Key]
        public string Id;

        public string Name;
        public List<Car> Cars;
        public string Email;

        public Dealer()
        {
            Id = "";
            Name = "";
            Cars = new List<Car>();
            Email = "";
        }

        public Dealer(string id, string name, List<Car> car, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Cars = car;
            this.Email = email;
        }
    }
}