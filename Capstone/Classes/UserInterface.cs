using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {
        private CateringSystem catering = new CateringSystem();




        public void RunMainMenu()
        {

            bool done = false;

            try
            {


                while (!done)
                {
                    Console.WriteLine("Welcome to Weyland Catering Corporation! please choose an option");

                    Console.WriteLine("(1) Display Catering Items");
                    Console.WriteLine("(2) Order");
                    Console.WriteLine("(3) Quit Application");

                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        foreach (CateringItem item in catering.items)
                        {

                            Console.WriteLine(item);

                        }
                        //get information from fileAccess, all catering items and properties 
                        // display said information in its entirety + amount of said item, 10 max

                    }
                    if (option == "2")
                    {
                        RunOrderMenu();

                    }
                    if (option == "3")
                    {
                        Console.WriteLine("Goodbye come again!");
                        done = true;

                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void RunOrderMenu()
        {
            bool done = false;

            int purchaseQuantity = 0;
            try
            {
                while (!done)
                {
                    Console.WriteLine("Please select option below");

                    Console.WriteLine("(1) Add Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Complete Transaction");
                    Console.WriteLine("Your current account balance is " + catering.AccountBalance.ToString("C"));
                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("How much money would you like to add?");
                        string depositAmount = Console.ReadLine();
                        decimal deposit = decimal.Parse(depositAmount);
                        catering.AddMoney(deposit);
                        if (deposit < 0)
                        {
                            Console.WriteLine("Deposits cannot be negative.");
                        }

                    }
                    if (option == "2")
                    {
                        Console.WriteLine("Please select a product ID.");
                        string productID = Console.ReadLine();
                        productID.ToUpper();
                        Console.WriteLine("Please select a quantity for this item.");
                        purchaseQuantity = int.Parse(Console.ReadLine());
                        int productAmount = catering.SelectCateringItems(productID, purchaseQuantity);
                        if (productAmount > 0)
                        {
                            Console.WriteLine("You've selected " + productAmount + " of this product");
                        }
                        else if (productAmount == 0)
                        {
                            Console.WriteLine("Item is sold out or item ID is not valid.");
                        }
                        else if (productAmount == -1)
                        {
                            Console.WriteLine("Insufficient stock to complete order");
                        }

                    }
                    if (option == "3")
                    {
                        decimal totalInvoiceAmount = 0;

                        decimal transactionAmount = catering.CompleteCateringTransaction(purchaseQuantity);
                        Console.WriteLine("Total balance:" + transactionAmount.ToString("C"));
                        foreach (InvoiceItem item in catering.invoice)
                        {
                            Console.WriteLine(item);
                            totalInvoiceAmount += item.TotalItemAmount;
                        }
                        Console.WriteLine("Total: " + totalInvoiceAmount);

                        Console.WriteLine("Twenties: " + catering.twenties);
                        Console.WriteLine("Tens: " + catering.tens);
                        Console.WriteLine("Fives: " + catering.fives);
                        Console.WriteLine("Ones: " + catering.ones);
                        Console.WriteLine("Quarters: " + catering.quarters);
                        Console.WriteLine("Dimes: " + catering.dimes);
                        Console.WriteLine("Nickels: " + catering.nickels);

                        transactionAmount = catering.EraseList();

                        done = true;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
