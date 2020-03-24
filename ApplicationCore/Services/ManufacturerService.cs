using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public class ManufacturerService
    {
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;
        public ManufacturerService(IAsyncRepository<Manufacturer> manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        public async Task CreateManufacturerAsync(string name, string country)
        {
            var manufacturer = new Manufacturer() { Name = name, Country = country };
            
            await _manufacturerRepository.AddAsync(manufacturer);
        }

        public async Task DeleteManufacturerAsync(int id)
        {

            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);

            await _manufacturerRepository.DeleteAsync(manufacturer);
        }
        public async Task<List<Manufacturer>> ReadAllManufacturer()
        {
            return await _manufacturerRepository.ListAllAsync();
            
        }
       
        public async Task<Manufacturer> UpdateManufacturer(int id, string name, string country)
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);
            manufacturer.Country = country;
            manufacturer.Name = name;
            return await _manufacturerRepository.UpdateAsync(manufacturer);
        }

        public async Task<Manufacturer> GetByIdAsync(int id)
        {
            return await _manufacturerRepository.GetByIdAsync(id);
        }
    }
}
