using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using AutoMapper;
using Google;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAdminEShop.Models;


namespace WebAdminEShop.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService iProdSrvice;
        IManufacturerService iManuFService;
        ISpeciesService iSpecies;
        IWebHostEnvironment iAppEnvironment;
        private string[] permittedExtensions = { ".jpg" };
        

        public ProductController(IProductService iproductservice, IManufacturerService imanufacturerService,ISpeciesService ispec, IWebHostEnvironment iwebhost)
        {
            iProdSrvice = iproductservice;
            iManuFService = imanufacturerService;
            iSpecies = ispec;
            iAppEnvironment = iwebhost;
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
            ProductDTO prodDTO = new ProductDTO
            {
                ManufacturerSource = (await iManuFService.ReadAllManufacturer()).
                                   Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                SpeciesSource = (await iSpecies.ReadAllSpecies()).
                                    Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()
            };
            return View(prodDTO);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO prod,IFormFile uploadFile)
        {
            
            if (!ModelState.IsValid)
            {

                await InitialDropDownList(prod);
                return View(prod);
            }
            var ext = Path.GetExtension(uploadFile.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                await InitialDropDownList(prod);
                prod.Error = "Need .jpg extension";
                return View(prod);
            }
            using (var image = Image.FromStream(uploadFile.OpenReadStream()))
            {
                if(image.Height < 500 || image.Height != image.Width )
                {
                    await InitialDropDownList(prod);
                    prod.Error = "Image is less than 500";
                    return View(prod);
                }
            }

            if (uploadFile != null )
                {
                    string path = "/Images/" + uploadFile.FileName;

                    using (var fileStream = new FileStream(iAppEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileStream);
                    }
                
                prod.Image = path;
                }
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>());
            var mapper = new Mapper(config);
            Product product = mapper.Map<ProductDTO, Product>(prod);
            await iProdSrvice.CreatePoductAsync(product);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prod = await iProdSrvice.GetByIdAsync(id);
            if(prod.Id != 0)
            {
                await iProdSrvice.DeleteProduct(id);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var prod = await iProdSrvice.GetByIdAsync(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = new Mapper(config);
            ProductDTO prDTO =  mapper.Map<Product, ProductDTO>(prod);
            await InitialDropDownList(prDTO);
            return View(prDTO);
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductDTO prod, IFormFile uploadFile)
        {
             
            if (!ModelState.IsValid)
            {
                await InitialDropDownList(prod);

                return View(prod);

            }
            if (uploadFile != null)
            {
                string path = "/Images/" + uploadFile.FileName;

                using (var fileStream = new FileStream(iAppEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileStream);
                }
                prod.Image = path; 
            }

            var ext = Path.GetExtension(uploadFile.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                await InitialDropDownList(prod);
                prod.Error = "Need .jpg extension";
                return View(prod);
            }
            using (var image = Image.FromStream(uploadFile.OpenReadStream()))
            {
                if (image.Height < 500 || image.Height != image.Width)
                {
                    await InitialDropDownList(prod);
                    prod.Error = "Image is less than 500"; 
                    return View(prod);
                }
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>());
            var mapper = new Mapper(config);

            Product product = mapper.Map<ProductDTO, Product>(prod);
            await iProdSrvice.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        public async Task<ProductDTO> InitialDropDownList(ProductDTO prod)
        {
            prod.ManufacturerSource = (await iManuFService.ReadAllManufacturer()).
                                   Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            prod.SpeciesSource = (await iSpecies.ReadAllSpecies()).
                                    Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return prod;
        }
    }
    
}