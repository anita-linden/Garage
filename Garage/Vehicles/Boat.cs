using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Boat : Vehicle
    {
        public decimal Length { get; private set; }

        public Boat(string reg, string col, decimal length) : base(reg, col, 0, "boat")
        {
            Length = length;
        }

    }
}
