using Cars.BL.Interfaces;
using Cars.DL.Interfaces;
using Cars.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.BL.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelService _modelRepository;
        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = (IModelService?)modelRepository;
        }


        public void Add(Model medicine)
        {
            _modelRepository.Add(medicine);
        }

        public List<Model> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public Model GetById(int id)
        {
            return _modelRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _modelRepository.Remove(id);
        }

        public List<Model> GetAllModelsByManufacturerId(int modelId)
        {
            return _modelRepository.GetAllModelsByManufacturerId(modelId);
        }

        public int TestCalculation(int number)
        {
            var models = _modelRepository.GetAll();
            return models.Count() + number;

        }
    }
}
