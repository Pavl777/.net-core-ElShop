using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IFridgeService
    {
        Task CreateFridgeAsync(int volume, string color, int power);
        Task DeleteFridgeAsync(int id);
        Task<List<Fridge>> ReadAllFridges();
        Task<Fridge> UpdateFridge(int id, int volume, string color, int power);
        Task<Fridge> GetByIdAsync(int id);


    }
}
