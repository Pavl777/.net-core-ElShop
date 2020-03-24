using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
   public class PhoneService
    {
        private readonly IAsyncRepository<Phone> _phoneRepository;

        PhoneService(IAsyncRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public async Task CreatePhoneAsync(string model, int battery, int screenArea)
        {
            var phone = new Phone { Model = model, Battery = battery, ScreenArea = screenArea };
            await _phoneRepository.AddAsync(phone);
        }

        public async Task DeletePhoneAsync(int id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            await _phoneRepository.DeleteAsync(phone);
        }

        public async Task<List<Phone>> ReadAllPhones()
        {
            return await _phoneRepository.ListAllAsync();
        }
        public async Task<Phone> UpdatePhone(int id, string model, int battery, int screenArea)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            phone.Model = model;
            phone.Battery = battery;
            phone.ScreenArea = screenArea;

            return await _phoneRepository.UpdateAsync(phone);
            
        }

        public async Task<Phone> GetByIdAsync(int id)
        {
            return await _phoneRepository.GetByIdAsync(id);
        }
    }
}
