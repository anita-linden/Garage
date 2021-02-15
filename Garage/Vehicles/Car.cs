using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Car : Vehicle
    {
        public enum Fuel
        {
            Gasoline,
            Diesel
        }

        public Fuel Fueltype { get; private set; }

        public Car (string reg, string col, int wheels, Fuel fueltype) : base(reg,col,wheels,"car")
        {
            if (wheels < 3 || wheels > 4)
                throw new ArgumentException("A car can have 3 or 4 wheels");
            Fueltype = fueltype;
        }
    }
}
