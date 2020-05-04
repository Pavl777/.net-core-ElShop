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
        Task<Product> UpdateProduct(Product product);
        Task<Product> GetByIdAsync(int id);
    }
}
