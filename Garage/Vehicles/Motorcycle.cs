using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Motorcycle : Vehicle
    {
        public decimal CylinderVolume { get; private set; }

        public Motorcycle(string reg, string col, decimal cylinderVolume) : base(reg, col, 2, "motorcycle")
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
