using Cars.BL.Interfaces;
using Cars.Models.Request;
using Cars.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cars.BL.Services.StoreService;

namespace Cars.BL.Services
{

    public class StoreService : IStoreService
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IModelService _modelService;

        public StoreService(IManufacturerService manufacturerService, IModelService modelService)
        {
            _manufacturerService = manufacturerService;
            _modelService = modelService;
        }

        public GetModelsByManufacturerResponse? GetModelsByManufacturer(GetModelsByManufacturerRequest request)
        {
            var models = _modelService.GetAllModelsByManufacturerId(request.ManufacturerId);

            if (models != null && models.Count > 0)
            {
                var response = new GetModelsByManufacturerResponse
                {
                    Manufacturer = _manufacturerService.GetById(request.ManufacturerId),
                    Models = models
                    .Where(product =>
                        (product.Price >= request.MinPrice) &&
                        (product.Price <= request.MaxPrice))
                    .ToList()
                };
                return response;
            }
            return null;
        }
    };
}

