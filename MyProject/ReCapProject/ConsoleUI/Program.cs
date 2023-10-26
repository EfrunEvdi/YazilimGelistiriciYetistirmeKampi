using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

// Car7GunOdev();

// Car8GunOdev();

// Car9GunOdev();

// Brand9GunOdev();

// Color9GunOden();

static void Car7GunOdev()
{
    CarManager carManager = new CarManager(new InMemoryCarDal());

    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine(car.ModelYear + " => " + car.Description);
    }
}

static void Car8GunOdev()
{
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
}

static void Car9GunOdev()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine($"{car.CarName} adlı araba {car.BrandName} marka ve {car.ColorName} rengindedir. Günlük ücreti {car.DailyPrice}tl'dir.");
    }
}

static void Brand9GunOdev()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());

    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void Color9GunOden()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine(color.ColorName);
    }
}