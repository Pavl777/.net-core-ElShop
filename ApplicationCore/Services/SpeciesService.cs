using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public class SpeciesService : ISpeciesService
    {
        private readonly IAsyncRepository<Species> _speciesRepository;
        public SpeciesService(IAsyncRepository<Species> speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }
        public async Task CreateSpeciesAsync(string name)
        {
            var species = new Species() { Name = name };

            await _speciesRepository.AddAsync(species);
        }

        public async Task DeleteSpeciesAsync(int id)
        {

            var species = await _speciesRepository.GetByIdAsync(id);

            await _speciesRepository.DeleteAsync(species);
        }
        public async Task<List<Species>> ReadAllSpecies()
        {
            return await _speciesRepository.ListAllAsync();

        }

        public async Task<Species> UpdateSpecies(int id, string name)
        {
            var species = await _speciesRepository.GetByIdAsync(id);
            species.Name = name;
            
            return await _speciesRepository.UpdateAsync(species);
        }

        public async Task<Species> GetByIdAsync(int id)
        {
            return await _speciesRepository.GetByIdAsync(id);
        }
    }
}
