using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public class Car : IVehicle
    {
        public bool HasTrailer { get; }
        public int Distance { get; }
        public string Name { get 
            {
                if (this.HasTrailer == true)
                {
                    return "carHasTrailer";
                }
                else if (this.HasTrailer == false)
                {
                      
                }
                return "carHasNoTrailer";
            } 
        }

        public Car(bool hasTrailer)
        {
            this.HasTrailer = hasTrailer;
        }
        
        public double CalculateToll(int distance)
        {
            double toll = distance * 0.020;

            if (this.HasTrailer == true) 
            {
                toll += 1.00;
                
            }
            return toll;

        }

    }

   
}
