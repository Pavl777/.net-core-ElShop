using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminEShop.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        
        public string Image { get; set; }

        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public int SpeciesId { get; set; }
       
        public int ManufacturerId { get; set; }
        
        public string Description { get; set; }
        public List<SelectListItem> ManufacturerSource { get; set; }
        public List<SelectListItem> SpeciesSource { get; set; }
        
    }

    public class ProductDTOValidation : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidation()
        {
            RuleFor(x => x.Name).Length(0,25).NotEmpty();
            RuleFor(x => x.Price).InclusiveBetween(1, 60000);
            RuleFor(x => x.SpeciesId).NotNull();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
