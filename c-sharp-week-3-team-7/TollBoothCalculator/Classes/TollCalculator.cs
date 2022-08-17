using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public class TollCalculator
    {
        public static void Main(string[] args)
        {
            

            Random getRandom = new Random();


            Car carHasNoTrailer = new Car(false);
            Car carHasTrailer = new Car(true);
            Truck has4Axles = new Truck(0, 4);
            Truck has6Axles = new Truck(0, 6);
            Truck has8OrMoreAxles = new Truck(0, 8);
            Tank freeRide = new Tank();




            List<IVehicle> vehicles = new List<IVehicle>();
            vehicles.Add(carHasNoTrailer);
            vehicles.Add(carHasTrailer);
            vehicles.Add(has4Axles);
            vehicles.Add(has6Axles);
            vehicles.Add(has8OrMoreAxles);
            vehicles.Add(freeRide);



            foreach (IVehicle vehicle in vehicles)
            {
                int distance = getRandom.Next(10, 250);
                double toll = vehicle.CalculateToll(distance);
                
                Console.WriteLine(vehicle.Name + " " + distance + " " + toll);



            }









        }




    }
}
