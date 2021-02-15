using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Airplane : Vehicle
    {
        public int NumberOfEngines { get; private set; }

        public Airplane(string reg, string col, int wheels, int engines) : base(reg,col,wheels,"airplane")
        {
            NumberOfEngines = engines;
        }
    }
}
