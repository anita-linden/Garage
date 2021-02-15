using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Garage.Test
{
    [TestClass]
    public class GarageTest
    {
        private List<IVehicle> testList = new List<IVehicle>();

        [TestMethod]
        public void ConstructorTest()
        {
            int size = 5;

            Garage<IVehicle> garage = new Garage<IVehicle>(size);

            Assert.AreEqual(size, garage.Size);
        }

        [TestMethod]
        public void ConstructWithVehiclesTest()
        {
            testList.Add(new Motorcycle("JSH546", "Pink", 700));
            testList.Add(new Motorcycle("COL573", "Black", 800));

            try
            {
                Garage<IVehicle> garage = new Garage<IVehicle>(3, testList.ToArray());

                Assert.AreEqual(testList[1], garage[1]);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void ListVehiclesTest()
        {
            testList.Add(new Motorcycle("JSH546", "Pink", 700));
            testList.Add(new Motorcycle("COL573", "Black", 800));

            try
            {
                Garage<IVehicle> garage = new Garage<IVehicle>(3, testList.ToArray());

                List<IVehicle> list = garage.ListVehicles();

                Assert.AreEqual(testList[0].RegistryNr, list[0].RegistryNr);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void ListVehiclesByTypeTest()
        {
            testList.Add(new Motorcycle("JSH546", "Pink", 700));
            testList.Add(new Motorcycle("COL573", "Black", 800));
            testList.Add(new Boat("KJL232", "Gaudy", 19));

            try
            {
                Garage<IVehicle> garage = new Garage<IVehicle>(3, testList.ToArray());

                string[] vehicles = garage.ListVehiclesByType();

                Assert.IsTrue(vehicles[0].Contains("Motorcycle") || vehicles[1].Contains('1'));
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void FindVehicleTest()
        {
            testList.Add(new Motorcycle("JSH546", "Pink", 700));
            testList.Add(new Motorcycle("COL573", "Black", 800));
            testList.Add(new Boat("KJL232", "Gaudy", 19));

            try
            {
                Garage<IVehicle> garage = new Garage<IVehicle>(3);
                foreach (IVehicle v in testList)
                {
                    garage.AddVehicle(v);
                }

                Assert.AreEqual(garage.FindVehicle("KJL232").Color, testList[2].Color);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void FindVehiclesTest()
        {
            testList.Add(new Motorcycle("JSH546", "Pink", 700));
            testList.Add(new Motorcycle("COL573", "Black", 800));
            testList.Add(new Boat("KJL232", "Gaudy", 19));
            testList.Add(new Car("TRP404", "Gaudy", 4, Car.Fuel.Diesel));

            try
            {
                int count = 0;
                Garage<IVehicle> garage = new Garage<IVehicle>(3);
                foreach (IVehicle v in testList)
                    garage.AddVehicle(v);
                foreach (IVehicle v in garage.FindVehicles(color: "Gaudy"))
                {
                    count += 1;
                }

                Assert.AreEqual(count, 2);
            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void AddVehicleTest()
        {
            try
            {

            }
            finally
            {
                CleanUp();
            }
        }

        [TestMethod]
        public void RemoveVehicleTest()
        {
            try
            {

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
