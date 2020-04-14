using ApplicationCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
   public interface IProductService
    {
        Task CreatePoductAsync(Product product);
        Task DeleteProduct(int id);
        Task<List<Product>> ReadAllProduct();
        Task<Product> UpdateProduct(int id, string name, int price, string description, int speciesId,
                                            int manufacturerId, int fridgeId, int phoneId, int microwaveId);
        Task<Product> GetByIdAsync(int id);
    }
}
