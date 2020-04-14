using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IPhoneService
    {
        Task CreatePhoneAsync(string model, int battery, int screenArea);
        Task DeletePhoneAsync(int id);
        Task<List<Phone>> ReadAllPhones();
        Task<Phone> UpdatePhone(int id, string model, int battery, int screenArea);
        Task<Phone> GetByIdAsync(int id);
    }
}
