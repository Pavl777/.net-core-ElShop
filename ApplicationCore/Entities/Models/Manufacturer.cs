using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public List<Product> Products { get; set; }

    }
}
