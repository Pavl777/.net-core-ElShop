using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IManufacturerService
    {
        Task CreateManufacturerAsync(string name, string country);
        Task DeleteManufacturerAsync(int id);
        Task<List<Manufacturer>> ReadAllManufacturer();
        Task<Manufacturer> UpdateManufacturer(int id, string name, string country);
        Task<Manufacturer> GetByIdAsync(int id);
    }
}
