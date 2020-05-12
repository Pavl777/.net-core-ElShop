using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Product : BaseEntity
    {
       public string Image { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int? PhoneId { get; set; }
        public Phone Phone { get; set; }
        public Fridge Fridge { get; set; }
        public int? FridgeId { get; set; }
        public Microwave Microwave { get; set; }
        public int? MicrowaveId { get; set; }
        //public Product( string name, int price, string manufacturer) : base()
        //{
        //    Name = name;
        //    Price = price;
        //    Manufacturer = manufacturer;
        //}
    }
}
