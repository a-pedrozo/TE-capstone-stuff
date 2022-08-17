using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {   // repeats program
            bool keepGoing = true;
            while (keepGoing == true) 
            {
                double newNumber = 0.0;
                Console.Write("Hello! please enter a number you'd like to convert:");
                string response = Console.ReadLine();
                double number = double.Parse(response);
                Console.Write("Is this number in feet (f) or meters (m)?");
                string determination = Console.ReadLine();
                if (determination == "f" || determination == "F")
                {
                    // Conversion Formula: m = f * 0.3048
                    newNumber = number * 0.3048;
                    Console.Write("Your new measurement in meters is " + newNumber + ".");
                }
                else if (determination == "m" || determination == "M")
                {
                    //Conversion Formula: f = m * 3.2808399
                    newNumber = number * 3.2808399;
                    Console.Write("Your new measurement in feet is " + newNumber + ".");
                    
                }
                Console.Write("Do you want to convert another number? (Y or N)?");
                string response2 = Console.ReadLine();
                if (response2 == "N" || response2 == "n")
                {
                    keepGoing = false;
                }

            }
        }
    }
}
