using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cars.BL.Interfaces;
using Cars.Models.User;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet("GetManufacturerById")]
        public Manufacturer GetManufacturerById(int id)
        {
            return _manufacturerService.GetById(id);
        }

        [HttpGet("GetAll")]
        public List<Manufacturer> GetAllManacturers()
        {
            return _manufacturerService.GetAll();
        }

        [HttpPost]
        public void Add([FromBody] Manufacturer manufacturer)
        {
            _manufacturerService.Add(manufacturer);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _manufacturerService.Remove(id);
        }
    }
}
