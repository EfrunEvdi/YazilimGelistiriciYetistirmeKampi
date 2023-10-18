using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear=2000, DailyPrice=1500000,Description="Araba 1"},
            new Car{ CarId=2, BrandId=2, ColorId=2, ModelYear=2000, DailyPrice=1500000,Description="Araba 2"},
            new Car{ CarId=3, BrandId=3, ColorId=3, ModelYear=2000, DailyPrice=1500000,Description="Araba 3"},
            new Car{ CarId=4, BrandId=4, ColorId=4, ModelYear=2000, DailyPrice=1500000,Description="Araba 4"},
            new Car{ CarId=5, BrandId=5, ColorId=5, ModelYear=2000, DailyPrice=1500000,Description="Araba 5"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
