using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
  public  class ProductService :IProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;

        public ProductService(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreatePoductAsync(Product product)
        {
            
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            await _productRepository.DeleteAsync(product);
        }
        public async Task<List<Product>> ReadAllProduct()
        {
            return await _productRepository.ListAllAsync();

        }
        public async Task<Product> UpdateProduct(int id, string name, int price, string description, int speciesId,
                                            int manufacturerId, int fridgeId, int phoneId, int microwaveId)
        {
            var product = await _productRepository.GetByIdAsync(id);
            product.Name = name;
            product.Price = price;
            product.Description = description;
            product.SpeciesId = speciesId;
            product.ManufacturerId = manufacturerId;
            product.FridgeId = fridgeId;
            product.PhoneId = phoneId;
            product.MicrowaveId = microwaveId;
            return await _productRepository.UpdateAsync(product);
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
