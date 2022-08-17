using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.Write("Hello, please enter a whole number to convert:");
                string numberToBinary = Console.ReadLine();
                int binaryParse = int.Parse(numberToBinary);
                string binary = Convert.ToString(binaryParse, 2);
                Console.WriteLine(numberToBinary + " in binary code is " + binary);
                Console.Write("Do you want to convert another number? (Y or N)?");
                string response = Console.ReadLine();
                if (response == "N" || response == "n")
                {
                    keepGoing = false;
                }
            }
        }
    }
}
/*
// int value = 8;
string binary = Convert.ToString(value, 2);
// binary to base 10
int value = Convert.ToInt32("1101", 2) 
*/