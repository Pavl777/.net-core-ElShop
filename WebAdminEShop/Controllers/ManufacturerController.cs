using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Models;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAdminEShop.Models;

namespace WebAdminEShop.Controllers
{
    public class ManufacturerController : Controller
    {
        IManufacturerService manufacturerService;
        public ManufacturerController(IManufacturerService _manufacturerService)
        {
            manufacturerService = _manufacturerService;
        }
         public async Task<IActionResult> AddManufacturer()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> AddManufacturer(ManufacturerDTO manDTO, string country)
        {
            if(!ModelState.IsValid)
            {
                return await Task.Run(() => View(manDTO));
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerDTO, Manufacturer>());
            var mapper = new Mapper(config);

            Manufacturer manufacturer = mapper.Map<ManufacturerDTO, Manufacturer>(manDTO);
            country = "USA";
            await manufacturerService.CreateManufacturerAsync(manDTO.Name, country);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await manufacturerService.GetByIdAsync(id);
            if (manufacturer.Id != 0)
            {
                await manufacturerService.DeleteManufacturerAsync(id);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateManufacturer(int id)
        {
            var manufacturer = await manufacturerService.GetByIdAsync(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer, ManufacturerDTO>());
            var mapper = new Mapper(config);
            ManufacturerDTO manDTO = mapper.Map<Manufacturer, ManufacturerDTO>(manufacturer);
            
            return View(manDTO);

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateManufacturer(ManufacturerDTO manuf, string country)
        {
        
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ManufacturerDTO, Manufacturer>());
            var mapper = new Mapper(config);

            Manufacturer manufacturer = mapper.Map<ManufacturerDTO, Manufacturer>(manuf);
            country = "USA";
            await manufacturerService.UpdateManufacturer(manufacturer.Id, manufacturer.Name, country);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer, ManufacturerDTO>());
            var mapper = new Mapper(config);
            var manufacturers = mapper.Map<List<ManufacturerDTO>>(await manufacturerService.ReadAllManufacturer());
            return View(manufacturers);
            
        }
      
    }
}