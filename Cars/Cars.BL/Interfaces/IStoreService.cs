using Cars.Models.Request;
using Cars.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.BL.Interfaces
{
    public interface IStoreService
    {
        GetModelsByManufacturerResponse? GetModelsByManufacturer(GetModelsByManufacturerRequest request);
    }
}
