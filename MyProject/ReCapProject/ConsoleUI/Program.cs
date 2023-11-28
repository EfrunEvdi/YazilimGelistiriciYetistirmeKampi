using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.Extensions.Logging;

#region Eski Kısım
// Car7GunOdev();

// Car8GunOdev();

// Car9GunOdev();

// Brand9GunOdev();

// Color9GunOden();

//static void Car7GunOdev()
//{
//    CarManager carManager = new CarManager(new InMemoryCarDal());

//    foreach (var car in carManager.GetAll())
//    {
//        Console.WriteLine(car.ModelYear + " => " + car.Description);
//    }
//}

//static void Car8GunOdev()
//{
//    CarManager carManager = new CarManager(new EfCarDal());

//    foreach (var product in carManager.GetCarsByBrandId(2))
//    {
//        Console.WriteLine(product.Name);
//    }

//    Console.WriteLine("**********************");

//    foreach (var product1 in carManager.GetCarsByColorId(1))
//    {
//        Console.WriteLine(product1.Name);
//    }

//    Car newCar = new Car
//    {
//        Name = "Deneme",
//        DailyPrice = 150,
//        ColorId = 1,
//        BrandId = 1,
//        ModelYear = 2023,
//        Description = "Deneme"
//    };

//    Console.WriteLine("Adding a new car...");
//    carManager.Add(newCar);

//    Console.ReadLine();
//}

//static void Car9GunOdev()
//{
//    CarManager carManager = new CarManager(new EfCarDal());

//    foreach (var car in carManager.GetCarDetails())
//    {
//        Console.WriteLine($"{car.CarName} adlı araba {car.BrandName} marka ve {car.ColorName} rengindedir. Günlük ücreti {car.DailyPrice}tl'dir.");
//    }
//}

//static void Brand9GunOdev()
//{
//    BrandManager brandManager = new BrandManager(new EfBrandDal());

//    foreach (var brand in brandManager.GetAll())
//    {
//        Console.WriteLine(brand.BrandName);
//    }
//}

//static void Color9GunOdev()
//{
//    ColorManager colorManager = new ColorManager(new EfColorDal());

//    foreach (var color in colorManager.GetAll())
//    {
//        Console.WriteLine(color.ColorName);
//    }
//}
#endregion

//CarAdd();
//CarTest();
//BrandTest();
//ColorTest();
//UserAdd();
//CustomerAdd();
//UserUpdate();
//RentalTest();
//RentalAdd();

static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    foreach (var rental in rentalManager.GetAll().Data)
    {
        Console.WriteLine(rental.RentDate);
    }
}

static void RentalAdd()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    Rental rental = new Rental()
    {
        CarId = 1,
        CustomerId = 1,
        RentDate = DateTime.Now,
        ReturnDate = DateTime.Now
    };

    rentalManager.Add(rental);
}

static void UserAdd()
{
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Add(new User()
    {
        FirstName = "Efrun",
        LastName = "Evdi",
        Email = "efrun@gmail.com",
        Password = "Efrun123.",
    });
}

static void CarAdd()
{
    CarManager carManager = new CarManager(new EfCarDal());

    carManager.Add(new Car()
    {
        BrandId = 1,
        ColorId = 1,
        DailyPrice = 200,
        Description = "Deneme",
        ModelYear = 2000,
        Name = "Deneme"
    }); ;
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void CustomerAdd()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    customerManager.Add(new Customer()
    {
        UserId = 1,
        CompanyName = "Efrun"
    });
}

static void UserUpdate()
{
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Update(new User()
    {
        UserId = 1,
        FirstName = "Efrun",
        LastName = "Evdi",
        Email = "efrun@gmail.com",
        Password = "Efrun123."
    });
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());

    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.ColorName);
    }
}

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetails();

    if (result.Success == true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine("Araç Adı : " + car.CarName + " Araç Markası : " + car.BrandName + " Araç Rengi : " + car.ColorName);
        }
    }
    else
    {
        Console.WriteLine(Messages.Basarisiz);
    }
}