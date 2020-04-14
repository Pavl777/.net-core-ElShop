using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public class FridgeService : IFridgeService
    {
        private readonly IAsyncRepository<Fridge> _fridgeRepository;
        public FridgeService(IAsyncRepository<Fridge> fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }
        public async Task CreateFridgeAsync(int volume, string color, int power)
        {
            var fridge = new Fridge() {Volume = volume, Color = color, Power = power };

            await _fridgeRepository.AddAsync(fridge);
        }

        public async Task DeleteFridgeAsync(int id)
        {

            var fridge = await _fridgeRepository.GetByIdAsync(id);

            await _fridgeRepository.DeleteAsync(fridge);
        }
        public async Task<List<Fridge>> ReadAllFridges()
        {
            return await _fridgeRepository.ListAllAsync();

        }

        public async Task<Fridge> UpdateFridge(int id, int volume, string color, int power)
        {
            var fridge = await _fridgeRepository.GetByIdAsync(id);
            fridge.Volume = volume;
            fridge.Color = color;
            fridge.Power = power;

            return await _fridgeRepository.UpdateAsync(fridge);
        }

        public async Task<Fridge> GetByIdAsync(int id)
        {
            return await _fridgeRepository.GetByIdAsync(id);
        }
    }
}
