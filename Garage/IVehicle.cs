using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public interface IVehicle
    {
        private static List<string> registryNumbers = new List<string>();
        public string RegistryNr { get; protected set; }
        public string Color { get; protected set; }
        public int NrOfWheels { get; protected set; }

        public static void RemoveRegistry(string reg)
        {
            registryNumbers.Remove(reg);
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
