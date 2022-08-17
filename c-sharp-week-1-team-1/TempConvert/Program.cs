using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing double variable to store value for after conversion formula is calculated.
            double newTemperature = 0.0;
            bool keepGoing = true;
            // Main Code
            while (keepGoing == true)
            {
                Console.Write("Hello, please enter your temperature:");
                string temperature = Console.ReadLine();
                double tempNumber = double.Parse(temperature);
                Console.WriteLine("Is your temperature in Fahrenheit (F) or Celsius (C)?");
                string response = Console.ReadLine();
                if (response == "F" || response == "f")
                {
                    //Fahrenheit to Celsius: Tc = (Tf - 32) / 1.8
                    newTemperature = (tempNumber - 32) / 1.8;
                    Console.WriteLine("Your new temperature in Celsius is " + newTemperature + ".");
                }
                else if (response == "C" || response == "c")
                {
                    //Celsius to Fahrenheit: Tf = Tc * 1.8 + 32
                    newTemperature = (tempNumber * 1.8) + 32;
                    Console.WriteLine("Your new temperature in Fahrenheit is " + newTemperature + ".");
                }
                    Console.Write("Do you want to convert another temperature?");
                    string yayOrNay = Console.ReadLine();
                    if (yayOrNay == "N" || yayOrNay == "n")
                {
                    keepGoing = false;
                }


            }
        }
    }
}
