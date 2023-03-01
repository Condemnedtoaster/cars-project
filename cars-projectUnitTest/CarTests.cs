
using car;
using static car.Car;

namespace cars_projectUnitTest;

[TestClass]
public class CarTests
{
    //Bemærk hvis class Person er abstract kan der ikke laves instancer af klassen og dermed heller ingen unittest!!

    private ICar car = new Car { Id = 1, Model = "Opel", Price = 9000, LicensePlate = 3 };
    private ICar carModelNull = new Car { Id = 3, Model = null, Price = 1234, LicensePlate = 6 };
    private ICar carModelToShort = new Car { Id = 2, Model = "c", Price = 4321, LicensePlate = 5 };
    private ICar carPricetoolow = new Car { Id = 4, Model = "", Price = 0, LicensePlate = 5 };
    private ICar carLicensePlateTooLow = new Car { Id = 4, Model = "", Price = 4231, LicensePlate = 0 };
    private ICar carLicensePlateTooHigh = new Car { Id = 4, Model = "", Price = 4231, LicensePlate = 100 };
    [TestMethod]
    public void ToStringTest()
    {
        string str = car.ToString();
        Assert.AreEqual("Id=1, Model=Opel, Price=9000, LicensePlate=3", str);
    }

    [TestMethod]
    public void ValidateModelTest()
    {
        car.ValidateModel();

        Assert.ThrowsException<ArgumentNullException>(() => carModelNull.ValidateModel());
        Assert.ThrowsException<ArgumentException>(() => carModelToShort.ValidateModel());
    }

    [TestMethod]
    public void ValidatePriceTest()
    {
        car.ValidatePrice();
        Assert.ThrowsException<ArgumentException>(() => carPricetoolow.ValidatePrice());
    }

    public void ValidateLicensePlateTest()
    {
        car.ValidateLicensePlate();
        Assert.ThrowsException<ArgumentException>(() => carLicensePlateTooLow.ValidateLicensePlate());

        Assert.ThrowsException<ArgumentException>(() => carLicensePlateTooHigh.ValidateLicensePlate());
    }
   
   


}
