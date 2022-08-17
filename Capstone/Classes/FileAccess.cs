using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private const string DataDirectory = @"C:\Catering";

        // These files should be read from / written to in the DataDirectory
        private const string CateringFileName = @"cateringsystem.csv";
        private const string ReportFileName = @"totalsales.txt";

        // Adding items from cateringsystem.csv to list in CateringSystem
        public void ImportCateringList(CateringSystem cateringSystem)
        {
            string filePath = Path.Combine(DataDirectory, CateringFileName);
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] cateringArray = line.Split("|");

                    string type = cateringArray[0];
                    string Id = cateringArray[1];
                    string name = cateringArray[2];
                    decimal price = decimal.Parse(cateringArray[3]);
                    int quantity = 10;

                    if (type == "A")
                    {
                        Appetizer newAppetizer = new Appetizer(Id, name, price, quantity);
                        newAppetizer.ID = Id;
                        newAppetizer.Name = name;
                        newAppetizer.Price = price;
                        newAppetizer.Quantity = quantity;
                        cateringSystem.AddToCateringList(newAppetizer); //placeholder, may come up with better method of adding to CateringList
                    }

                    if (type == "B")
                    {
                        Beverage newBeverage = new Beverage(Id, name, price, quantity);
                        newBeverage.ID = Id;
                        newBeverage.Name = name;
                        newBeverage.Price = price;
                        cateringSystem.AddToCateringList(newBeverage);
                    }

                    if (type == "E")
                    {
                        Entree newEntree = new Entree(Id, name, price, quantity);
                        newEntree.ID = Id;
                        newEntree.Name = name;
                        newEntree.Price = price;
                        cateringSystem.AddToCateringList(newEntree);
                    }

                    if (type == "D")
                    {
                        Dessert newDessert = new Dessert(Id, name, price, quantity);
                        newDessert.ID = Id;
                        newDessert.Name = name;
                        newDessert.Price = price;
                        cateringSystem.AddToCateringList(newDessert);
                    }
                    

                }
            }


        }
        public void CreateAuditList(string methodInfo)
        {
            DateTime dateTime = DateTime.Now;
            string auditFilePath = Path.Combine(DataDirectory, ReportFileName);
            using(StreamWriter writer = new StreamWriter(auditFilePath, true))
            {
  
                    writer.WriteLine(dateTime + methodInfo);
            

            }
        }



    }
}
