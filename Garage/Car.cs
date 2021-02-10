using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Car : IVehicle
    {
        public enum Fuel
        {
            Gasoline,
            Diesel
        }

        public Fuel Fueltype { get; private set; }

        int IVehicle.RegistryNr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IVehicle.Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IVehicle.NrOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
