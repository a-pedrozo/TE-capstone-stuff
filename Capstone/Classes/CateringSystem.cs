using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering system management
    /// </summary>
    public class CateringSystem
    {

        public FileAccess auditFilePath = new FileAccess();
        public FileAccess filePath = new FileAccess();

        public CateringSystem()
        {
            filePath.ImportCateringList(this);
        }

        public List<CateringItem> items = new List<CateringItem>();
        public List<InvoiceItem> invoice = new List<InvoiceItem>();


        public CateringItem[] AllItems
        {
            get
            {
                return items.ToArray();
            }
        }



        public decimal AccountBalance { get; private set; }




        public void AddToCateringList(CateringItem newCateringItem)
        {
            items.Add(newCateringItem);
        }

        public decimal AddMoney(decimal depositAmount)
        {
            if (depositAmount >= 0 && (depositAmount + this.AccountBalance) <= 1000) // creating 1000 dollar cap limit
            {
                AccountBalance += depositAmount;
                auditFilePath.CreateAuditList(" Add Money " + depositAmount + " " + AccountBalance);
                return AccountBalance;
            }
            else if (depositAmount + this.AccountBalance > 1000)
            {
                AccountBalance = 1000;
                auditFilePath.CreateAuditList(" Add Money " + depositAmount + " " + AccountBalance);
                return AccountBalance;
            }
            return AccountBalance;
        }


        public int productAmount = 0;

        public int SelectCateringItems(string productID, int orderQuantity)
        {

            foreach (CateringItem item in items)
            {
                if ((productID == item.ID) && (item.Quantity >= orderQuantity))
                {
                    productAmount = orderQuantity;
                    item.Quantity -= orderQuantity;
                    InvoiceItem purchasedItem = new InvoiceItem(item.Type, item.ID, item.Name, item.Price, orderQuantity);
                    invoice.Add(purchasedItem);
                    auditFilePath.CreateAuditList(" Product Selected: " + purchasedItem + " " + AccountBalance);
                    return productAmount;

                }
                else if (orderQuantity > item.Quantity)
                {
                    productAmount = -1;
                    return productAmount;
                }
            }
            return productAmount;

        }

        public int twenties = 0;
        public int tens = 0;
        public int fives = 0;
        public int ones = 0;
        public int quarters = 0;
        public int dimes = 0;
        public int nickels = 0;

        public decimal transactionAmount = 0;
        
        /*public decimal GiveChange()
        {
            AccountBalance -= transactionAmount; // Method for making change
            twenties = (int) (AccountBalance / 20); // Number of twenty-dollar bills
            AccountBalance -= twenties* 20;
            tens = (int) (AccountBalance / 10); // Number of ten-dollar bills
            AccountBalance -= tens* 10;
            fives = (int) (AccountBalance / 5); // Number of five-dollar bills
            AccountBalance -= fives* 5;
            ones = (int) (AccountBalance / 1);
            AccountBalance -= ones* 1;
            quarters = (int) (AccountBalance / 0.25m);
            AccountBalance -= quarters* 0.25m;
            dimes = (int) (AccountBalance / 0.1m);
            AccountBalance -= dimes* 0.1m;
            nickels = (int) (AccountBalance / 0.05m);
            AccountBalance -= nickels* 0.05m;
            decimal Change = twenties * 20 + tens * 10 + fives * 5 + ones * 1 + quarters * 0.25m + dimes * 0.1m + nickels * 0.05m;
            auditFilePath.CreateAuditList(" Give Change " + Change + " " + AccountBalance);
            return AccountBalance;
        }*/

        public decimal CompleteCateringTransaction(int orderQuantity)
        {
            foreach (InvoiceItem item in invoice)
            {
                if (item.Quantity >= orderQuantity)
                {
                    transactionAmount = orderQuantity * item.Price;
                }  
                else
                {
                    transactionAmount = 0;
                }
            }

            AccountBalance -= transactionAmount; // Method for making change
            twenties = (int)(AccountBalance / 20); // Number of twenty-dollar bills
            AccountBalance -= twenties * 20;
            tens = (int)(AccountBalance / 10); // Number of ten-dollar bills
            AccountBalance -= tens * 10;
            fives = (int)(AccountBalance / 5); // Number of five-dollar bills
            AccountBalance -= fives * 5;
            ones = (int)(AccountBalance / 1);
            AccountBalance -= ones * 1;
            quarters = (int)(AccountBalance / 0.25m);
            AccountBalance -= quarters * 0.25m;
            dimes = (int)(AccountBalance / 0.1m);
            AccountBalance -= dimes * 0.1m;
            nickels = (int)(AccountBalance / 0.05m);
            AccountBalance -= nickels * 0.05m;
            decimal Change = twenties * 20 + tens * 10 + fives * 5 + ones * 1 + quarters * 0.25m + dimes * 0.1m + nickels * 0.05m;
            auditFilePath.CreateAuditList(" Give Change " + Change + " " + AccountBalance); 
            return AccountBalance;
        }

        public decimal EraseList()
        {
            invoice = new List<InvoiceItem>();
            return 0;
        }
        

    }
}
