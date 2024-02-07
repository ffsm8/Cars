using Cars.Models.User;
using Cars.DL.MemoryDb;
using Cars.DL.Interfaces;

using Moq;

namespace Cars.Test
{
    public class CarsTest
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
        [Fact]
        public void GetAllByManufacturerId_Count_Check()
        {
            var expectedCount = 1;
            var manufacturerId = 2;

            var mockedModelRepository = new Mock<IModelRepository>();
            mockedModelRepository.Setup(x => x.GetAllModelsByManufacturerId(manufacturerId))
                .Returns(ModelData.Where(p => p.ManufacturerId == manufacturerId).ToList());

            //injects
            var service = new ModelService(mockedModelRepository.Object);

            //act
            var result = service.GetAllModelsByManufacturerId(manufacturerId);

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void GetAllByManufacturerId_WrongId()
        {
            var expectedCount = 0;
            var manufacturerId = 4;

            var mockedMedicineRepository = new Mock<IModelRepository>();
            mockedMedicineRepository.Setup(x => x.GetAllModelsByManufacturerId(manufacturerId))
                .Returns(ModelData.Where(p => p.ManufacturerId == manufacturerId).ToList());

            //injects
            var service = new ModelService(mockedMedicineRepository.Object);

            //act
            var result = service.GetAllModelsByManufacturerId(manufacturerId);

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void TestCalculation_Result_Check()
        {
            var expectedResult = 13;
            var testNumber = 10;

            var mockedModelRepository = new Mock<IModelRepository>();
            mockedModelRepository.Setup(x => x.GetAll())
                .Returns(ModelData);

            //injects
            var service = new ModelService(mockedModelRepository.Object);

            //act
            var result = service.TestCalculation(testNumber);

            //assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Remove_Count_Check()
        {
            var expectedResult = 2;
            var modelId = 1;
            var modelToRemove = ModelData.FirstOrDefault(x => x.Id == modelId);

            var mockedModelRepository = new Mock<IModelRepository>();
            mockedModelRepository.Setup(x => x.Remove(modelId)).Callback(() =>
            {
                ModelData.Remove(modelToRemove);
            });

            //injects
            var service = new ModelService(mockedModelRepository.Object);

            //act
            service.Remove(modelId);

            //assert
            Assert.Equal(expectedResult, ModelData.Count);
        }
    }
}