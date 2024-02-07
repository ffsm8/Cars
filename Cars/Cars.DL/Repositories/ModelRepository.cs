using Cars.DL.Interfaces;
using Cars.DL.MemoryDb;
using Cars.Models.User;
using System.Reflection;

namespace Cars.DL.Repositories
{
    public class ModelRepository : IModelRepository
    {

        public List<Model> GetAll()
        {
            return InMemoryDb.ModelData;
        }
        public Model GetById(int id)
        {
            return InMemoryDb.ModelData.First(a => a.Id == id);
        }
        public void Add(Model Model)
        {
            InMemoryDb.ModelData.Add(Model);
        }
        public void Remove(int id)
        {
            var medicine = GetById(id);
            InMemoryDb.ModelData.Remove(medicine);
        }
        public List<Model> GetAllModelsByManufacturerId(int id)
        {
            var result = InMemoryDb.ModelData.Where(b => b.ManufacturerId == id).ToList();
            return result;
        }
    }
}
