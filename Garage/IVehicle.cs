using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public interface IVehicle
    {
        public string RegistryNr { get; }
        public string Color { get; }
        public int NrOfWheels { get; }
    }
}
