using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface ISpeciesService
    {
        Task CreateSpeciesAsync(string name);
        Task DeleteSpeciesAsync(int id);
        Task<List<Species>> ReadAllSpecies();
        Task<Species> UpdateSpecies(int id, string name);
        Task<Species> GetByIdAsync(int id);
    }
}
