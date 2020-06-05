using ApplicationCore.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdminEShop.Models
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Error { get; set; }
       
    }
    public class ManufacturerDTOValidation : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerDTOValidation()
        {

            RuleFor(x => x.Name).Length(0, 25).NotEmpty();

        }
    }
}
