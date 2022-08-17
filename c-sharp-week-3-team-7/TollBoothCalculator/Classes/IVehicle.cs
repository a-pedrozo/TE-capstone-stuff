using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    interface IVehicle
    {
        public int Distance 
        {
            get; 
        }

        public virtual double CalculateToll(int distance)
        {
            return distance;
            
        }
        string Name { get; }
    }
}
