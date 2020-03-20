using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Fridge : BaseEntity
    {
      
        public int Volume { get; set; }
        public string Color { get; set; }
        public int Power { get; set; }

        public Product FridgeProduct { get; set; }
    }
}
