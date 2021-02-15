using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    abstract class Vehicle : IVehicle
    {
        protected static List<string> registryNumbers = new List<string>();


        public static List<string> RegistryNumbers => registryNumbers;
        public string Type { get; private set; }
        public string RegistryNr { get; protected set; }
        public string Color { get; protected set; }
        public int NrOfWheels { get; protected set; }

        public Vehicle(string reg, string col, int wheels, string type)
        {
            SetRegistry(reg);
            Color = col;
            NrOfWheels = wheels;
            Type = type;
        }

        public void Delete()
        {
            registryNumbers.Remove(RegistryNr);
        }

        
        protected void SetRegistry(string registry)
        {
            foreach (var reg in registryNumbers)
            {
                if (reg == registry)
                    throw new ArgumentException("Duplicate registry numbers cannot exist");
            }


            RegistryNr = registry;
            registryNumbers.Add(registry);
        }
    }
}
