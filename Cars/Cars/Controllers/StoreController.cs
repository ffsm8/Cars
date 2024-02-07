using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cars.BL.Interfaces;
using Cars.BL.Services;
using Cars.Models.Request;
using Cars.Models.Response;
using Cars.Models.User;
using Cars.Validators;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public GetModelsByManufacturerResponse? GetModelsByManufacturer(GetModelsByManufacturerRequest request)
        {
            if (request == null) return null;

            return _storeService.GetModelsByManufacturer(request);

        }

        [HttpPost("TestEndpoint")]
        public string GetTestEndpoint([FromBody] GetModelsByManufacturerRequest request)
        {
            var validator = new GetModelsByManufacturerRequestValidator();

            var result = validator.Validate(request);
            if (result.IsValid)
            {
                return "Test Pass";
            }
            return "Test Didn't Pass";
        }
    }
}
