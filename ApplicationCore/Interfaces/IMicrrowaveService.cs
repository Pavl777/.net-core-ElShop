using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IMicrrowaveService
    {
        Task CreateMicrowaveAsync(int modeQuantity, bool isEmbed);
        Task DeleteMicrowave(int id);
        Task<List<Microwave>> ReadAllMicrowaves();
        Task<Microwave> UpdateMicrowave(int id, int modeQuantity, bool isEmbed);
        Task<Microwave> GetByIdAsync(int id);
    }
}
