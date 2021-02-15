using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Garage.Test
{
    [TestClass]
    public class VehicleTests
    {
        private List<IVehicle> testList = new List<IVehicle>();

        [TestMethod]
        public void TestRegistryValue()
        {
            string reg = "BFG9k";
            string col = "Grey";
            int wheels = 4;
            Car.Fuel fuel = Car.Fuel.Diesel;
            testList.Add(new Car(reg, col, wheels, fuel));

            try
            {
                Assert.AreEqual(reg, testList[0].RegistryNr);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void TestColor()
        {
            string reg = "BFG9k";
            string col = "Grey";
            int wheels = 4;
            Car.Fuel fuel = Car.Fuel.Diesel;
            testList.Add(new Car(reg, col, wheels, fuel));

            try
            {
                Assert.AreEqual(col, testList[0].Color);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void TestWheels()
        {
            string reg = "BFG9k";
            string col = "Grey";
            int wheels = 4;
            Car.Fuel fuel = Car.Fuel.Diesel;
            testList.Add(new Car(reg, col, wheels, fuel));

            try
            {
                Assert.AreEqual(wheels, testList[0].NrOfWheels);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void TestRegistryListRemoval()
        {
            var expectedFalse = "SFG2000";
            Car car = new Car(expectedFalse, "Red", 3, Car.Fuel.Gasoline);
            testList.Add(car);

            try
            {
                car.Delete();

                Assert.IsFalse(Vehicle.RegistryNumbers.Contains(expectedFalse));
            }
            finally
            {
                CleanUp();
            }
                
            
        }

        [TestMethod]
        public void TestRegistryList()
        {
            var expectedTru = "GMY345";
            Boat boat = new Boat(expectedTru, "Blue", 9);
            testList.Add(boat);

            try
            {
                Assert.IsTrue(Vehicle.RegistryNumbers.Contains(expectedTru));
            }
            finally
            {
                CleanUp();
            }
            
        }

        private void CleanUp()
        {
            foreach (IVehicle v in testList)
                v.Delete();
            testList = new List<IVehicle>();
        }
    }
}
