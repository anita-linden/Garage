using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Bus : Vehicle
    {
        public int NumberOfSeats { get; private set; }

        public Bus(string reg, string col, int wheels, int seats) : base(reg, col, wheels, "bus")
        {
            NumberOfSeats = seats;
        }
    }
}
