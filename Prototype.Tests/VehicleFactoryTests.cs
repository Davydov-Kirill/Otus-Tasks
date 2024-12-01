namespace Prototype.Test
{
    [TestFixture]
    public class VehicleFactoryTests
    {
        VehicleFactory factory = new VehicleFactory();

        #region Tests CreateVehicle method

        [Test]
        public void CreateVehicle_NullVehicle_ThrowArgumentNullException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => factory.CreateVehicle(null));

            StringAssert.Contains("Vehicle cannot be null.", ex.Message);
        }

        [Test]
        public void CreateVehicle_ValidCar_CloneCar()
        {
            var originalCar = new Car("Volkswagen", "Polo", 190, 4, FuelType.Petrol);

            var cloneCar = factory.CreateVehicle(originalCar);

            Assert.IsNotNull(cloneCar);
            Assert.AreEqual(originalCar.ToString(), cloneCar.ToString());
            Assert.AreNotSame(originalCar, cloneCar);
        }

        [Test]
        public void CreateVehicle_ValidTruck_CloneTruck()
        {
            var originalTruck = new Truck("Volvo", "FH", 120, 20000);

            var cloneTruck = factory.CreateVehicle(originalTruck);

            Assert.IsNotNull(cloneTruck);
            Assert.AreEqual(originalTruck.ToString(), cloneTruck.ToString());
            Assert.AreNotSame(originalTruck, cloneTruck);
        }

        [Test]
        public void CreateVehicle_ValidElectricCar_CloneElectricCar()
        {
            var originalElectricCar = new ElectricCar("Tesla", "Model S", 250, 4, FuelType.Electric, 100);

            var cloneElectricCar = factory.CreateVehicle(originalElectricCar);

            Assert.IsNotNull(cloneElectricCar);
            Assert.AreEqual(originalElectricCar.ToString(), cloneElectricCar.ToString());
            Assert.AreNotSame(originalElectricCar, cloneElectricCar);
        }

        #endregion

        #region Tests CreateVehicleUsingCloneable method

        [Test]
        public void CreateVehicleUsingCloneable_NullVehicle_ThrowArgumentNullException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => factory.CreateVehicleUsingCloneable(null));

            StringAssert.Contains("Vehicle cannot be null.", ex.Message);
        }

        [Test]
        public void CreateVehicleUsingCloneable_ValidCar_CloneCar()
        {
            var originalCar = new Car("Volkswagen", "Polo", 190, 4, FuelType.Petrol);

            var cloneCar = factory.CreateVehicleUsingCloneable(originalCar);

            Assert.IsNotNull(cloneCar);
            Assert.AreEqual(originalCar.ToString(), cloneCar.ToString());
            Assert.AreNotSame(originalCar, cloneCar);
        }

        [Test]
        public void CreateVehicleUsingCloneable_ValidTruck_CloneTruck()
        {
            var originalTruck = new Truck("Volvo", "FH", 120, 20000);

            var cloneTruck = factory.CreateVehicleUsingCloneable(originalTruck);

            Assert.IsNotNull(cloneTruck);
            Assert.AreEqual(originalTruck.ToString(), cloneTruck.ToString());
            Assert.AreNotSame(originalTruck, cloneTruck);
        }

        [Test]
        public void CreateVehicleUsingCloneable_ValidElectricCar_CloneElectricCar()
        {
            var originalElectricCar = new ElectricCar("Tesla", "Model S", 250, 4, FuelType.Electric, 100);

            var cloneElectricCar = factory.CreateVehicleUsingCloneable(originalElectricCar);

            Assert.IsNotNull(cloneElectricCar);
            Assert.AreEqual(originalElectricCar.ToString(), cloneElectricCar.ToString());
            Assert.AreNotSame(originalElectricCar, cloneElectricCar);
        }

        #endregion
    }
}
