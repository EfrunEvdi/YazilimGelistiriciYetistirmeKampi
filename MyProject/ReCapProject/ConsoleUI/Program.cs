using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//CarManager carManager = new CarManager(new InMemoryCarDal());

//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine(car.ModelYear + " => " + car.Description);
//}

CarManager carManager = new CarManager(new EfCarDal());

foreach (var product in carManager.GetCarsByBrandId(2))
{
    Console.WriteLine(product.Name);
}

Console.WriteLine("**********************");

foreach (var product1 in carManager.GetCarsByColorId(1))
{
    Console.WriteLine(product1.Name);
}

Car newCar = new Car
{
    Name = "Deneme",
    DailyPrice = 150,
    ColorId = 1,
    BrandId = 1,
    ModelYear = 2023,
    Description = "Deneme"
};

Console.WriteLine("Adding a new car...");
carManager.Add(newCar);

Console.ReadLine();