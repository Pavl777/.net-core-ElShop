using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Phone : BaseEntity
    {
        public string Model { get; set; }
        public int Battery { get; set; }
        public int ScreenArea { get; set; }

        public Product PhoneProduct { get; set; }
    }
}
