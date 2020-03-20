using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Species : BaseEntity
    {
        
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
