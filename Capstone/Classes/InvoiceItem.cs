using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// This class MUST be abstract
    /// This class MUST be inherited by at least 2 other classes
    /// Those other classes MUST be used in your program.
    /// </remarks>
    public class InvoiceItem
    {
        public InvoiceItem(string type, string Id, string name, decimal price, int quantity)
        {
            this.Type = type;
            this.ID = Id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;

        }

        public string Type { get; set; }

        public string ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalItemAmount 
        {
            get
            {
                return Price * Quantity;
            }
        }

        public override string ToString()
         {
            return $" {ID} {Name} {Price} quantity {Quantity} {TotalItemAmount} ";
         }




    }
}
