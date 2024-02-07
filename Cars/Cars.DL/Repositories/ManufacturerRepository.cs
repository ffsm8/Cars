using Cars.DL.Interfaces;
using Cars.DL.MemoryDb;
using Cars.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DL.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public List<Manufacturer> GetAll()
        {
            return InMemoryDb.ManufacturerData;
        }
        public Manufacturer GetById(int id)
        {
            return InMemoryDb.ManufacturerData.First(a => a.Id == id);
        }
        public void Add(Manufacturer manufacturer)
        {
            InMemoryDb.ManufacturerData.Add(manufacturer);
        }
        public void Remove(int id)
        {
            var manufacturer = GetById(id);
            InMemoryDb.ManufacturerData.Remove(manufacturer);
        }
    }
}
