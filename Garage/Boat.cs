using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Boat : Vehicle
    {
        public decimal Length { get; private set; }
        int IVehicle.RegistryNr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IVehicle.Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IVehicle.NrOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
