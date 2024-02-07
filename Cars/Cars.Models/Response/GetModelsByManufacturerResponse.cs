using Cars.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models.Response
{
    public class GetModelsByManufacturerResponse
    {

        public Manufacturer? Manufacturer { get; set; }

        public List<Model>? Models { get; set; }
    }
}

