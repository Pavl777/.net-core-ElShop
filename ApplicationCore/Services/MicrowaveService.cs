using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public class MicrowaveService : IMicrrowaveService
    {
        private readonly IAsyncRepository<Microwave> _microwaveRepository;

       public MicrowaveService(IAsyncRepository<Microwave> microwaveRepository)
        {
            _microwaveRepository = microwaveRepository;
        }

        public async Task CreateMicrowaveAsync(int modeQuantity, bool isEmbed)
        {
            var microwave = new Microwave() { ModeQuantity = modeQuantity, IsEmbed = isEmbed };
            await _microwaveRepository.AddAsync(microwave);
        }
        public async Task DeleteMicrowave(int id)
        {
            var microwave = await _microwaveRepository.GetByIdAsync(id);
            await _microwaveRepository.DeleteAsync(microwave);
        }

        public async Task<List<Microwave>> ReadAllMicrowaves()
        {
            return await _microwaveRepository.ListAllAsync();
        }

        public async Task<Microwave> UpdateMicrowave(int id, int modeQuantity, bool isEmbed)
        {
            var microwave = await _microwaveRepository.GetByIdAsync(id);
            microwave.ModeQuantity = modeQuantity;
            microwave.IsEmbed = isEmbed;
            return await _microwaveRepository.UpdateAsync(microwave);
        }

        public async Task<Microwave> GetByIdAsync(int id)
        {
            return await _microwaveRepository.GetByIdAsync(id);
        }
    }
}
