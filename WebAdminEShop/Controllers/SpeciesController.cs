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
    public class SpeciesController : Controller
    {
        ISpeciesService iSpeciesService;

        public SpeciesController(ISpeciesService _speciesService)
        {
            iSpeciesService = _speciesService ;
        }
        public async Task<IActionResult> AddSpecies()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecies(SpeciesDTO specDTO)
        {
            if(!ModelState.IsValid)
            {
                return await Task.Run(() => View(specDTO));
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SpeciesDTO, Species>());
            var mapper = new Mapper(config);
            Species species = mapper.Map<SpeciesDTO, Species>(specDTO);
            await iSpeciesService.CreateSpeciesAsync(specDTO.Name);
            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            var spec = await iSpeciesService.GetByIdAsync(id);
            if (spec.Id != 0)
            {
                await iSpeciesService.DeleteSpeciesAsync(id);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateSpecies(int id)
        {
            var spec = await iSpeciesService.GetByIdAsync(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Species, SpeciesDTO>());
            var mapper = new Mapper(config);
            SpeciesDTO specDTO = mapper.Map<Species, SpeciesDTO>(spec);
            
            return View(specDTO);

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecies(SpeciesDTO spec)
        {
        
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SpeciesDTO, Species>());
            var mapper = new Mapper(config);

            Species species = mapper.Map<SpeciesDTO, Species>(spec);
            await iSpeciesService.UpdateSpecies(species.Id, species.Name);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Species, SpeciesDTO>());
            var mapper = new Mapper(config);
            var products = mapper.Map<List<SpeciesDTO>>(await iSpeciesService.ReadAllSpecies());
            return View(products);
            
        }
    }
}