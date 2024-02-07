using Cars.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.BL.Interfaces
{
    public interface IModelService
    {
        List<Model> GetAll();

        Model GetById(int id);

        void Add(Model model);

        void Remove(int id);
        List<Model> GetAllModelsByManufacturerId(int modelId);

    }
}
