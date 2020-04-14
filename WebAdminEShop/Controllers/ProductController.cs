using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using WebAdminEShop.Models;

namespace WebAdminEShop.Controllers
{
    public class ProductController : Controller
    {
        IProductService iProdSrvice;
        public ProductController(IProductService iproductservice)
        {
            iProdSrvice = iproductservice;
            
        }
       
        
        public async Task <IActionResult> Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            var products =  mapper.Map<List<ProductDTO>>(await iProdSrvice.ReadAllProduct());
            return View( products);
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO prod)
        {
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>());
            var mapper = new Mapper(config);
            Product product = mapper.Map<ProductDTO, Product>(prod);
           await iProdSrvice.CreatePoductAsync(product);
            
            return View (prod);
        }
    }
}