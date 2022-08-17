using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public class Truck : IVehicle
    {
        public int NumberOfAxles { get; }
        public int Distance { get; }
        public string Name
        {
            get
            {
                if (this.NumberOfAxles >= 8)
                {
                    return "Truck 8 Axles";
                }
                else if (this.NumberOfAxles == 6)
                {
                    return "Truck 6 Axles";
                }
                else if (this.NumberOfAxles == 4) 
                {
                }
                    return "Truck 4 Axles";
            }
        }

        public Truck(int distance, int numberOfAxles)
        {
            this.NumberOfAxles = numberOfAxles;
            this.Distance = distance;
        }
        public double CalculateToll(int distance)
        {
            double perMile = 0;

            if (this.NumberOfAxles >= 8)
            {
                perMile = 0.048;
            }
            else if (this.NumberOfAxles == 6)
            {
                perMile = 0.045;
            }
            else if (this.NumberOfAxles == 4)
            {
                perMile = 0.040;
            }
            else
            {
                return 0; // if outside of scope;
            }

            double toll = distance * perMile;
            return toll;
        }

    }



}
