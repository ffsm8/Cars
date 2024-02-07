using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cars.BL.Interfaces;
using Cars.BL.Services;
using Cars.Models.User;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("GetBookById")]
        public Model GetModelById(int id)
        {
            return _modelService.GetById(id);
        }

        [HttpGet("GetAll")]
        public List<Model> GetAllByModel()
        {
            return _modelService.GetAll();
        }

        [HttpPost("Add")]
        public void Add([FromBody] Model model)
        {
            if (model == null) return;
            _modelService.Add(model);

        }

        [HttpDelete]
        public void Delete(int id)
        {
            _modelService.Remove(id);
        }
    }
}
