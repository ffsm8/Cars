using Cars.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars.DL.MemoryDb
{
    public static class InMemoryDb
    {
        public static List<Model> ModelData = new List<Model>() {
            new Model()
            {
            Id = 1,
            Name = "GLA 200",
            Price = 50000m,
            ManufacturerId = 1,
        },
        new Model()
        {
            Id = 2,
            Name = "i30",
            Price = 20000m,
            ManufacturerId = 2,
        },
        new Model()
        {
            Id = 3,
            Name = "Stelvio",
            Price = 40000m,
            ManufacturerId = 3,
        }
    };

        public static List<Manufacturer> ManufacturerData = new List<Manufacturer>()
        {
        new Manufacturer()
        {
            Id = 1,
            Name = "Mercedes-Benz",
            Country = "Germany"
        },
        new Manufacturer()
        {
            Id= 2,
            Name = "Hyundai",
            Country = "South Korea"
        },
        new Manufacturer()
        {
            Id = 3,
            Name = "Alfa Romeo",
            Country = "Italy"
        },
        };
    }
}
