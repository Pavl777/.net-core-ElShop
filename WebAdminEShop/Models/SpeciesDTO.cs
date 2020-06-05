using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminEShop.Models
{
    public class SpeciesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Error { get; set; }
    }
    public class SpeciesDTOValidation : AbstractValidator<ProductDTO>
    {
        public SpeciesDTOValidation()
        {

            RuleFor(x => x.Name).Length(0, 25).NotEmpty();
            
        }
    }
}
