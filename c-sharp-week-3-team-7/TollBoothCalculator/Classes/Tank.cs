using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
   public class Tank : IVehicle
    {
        public int Distance { get; }
        public string Name { get; } = "Tank";

        public Tank()
        {

        }
        public virtual double CalculateToll(int distance)
        {
            double toll = distance * 0;
            return toll;
        }



    }
}
