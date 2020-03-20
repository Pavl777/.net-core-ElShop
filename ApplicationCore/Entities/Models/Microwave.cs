using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Models
{
   public class Microwave : BaseEntity
    {
        public int ModeQuantity { get; set; }
        public bool IsEmbed { get; set; }
        public Product MicrowaveProduct { get; set; }
    }
}
