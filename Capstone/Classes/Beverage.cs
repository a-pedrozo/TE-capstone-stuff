using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Beverage : CateringItem
    {
        public Beverage(string Id, string name, decimal price, int quantity) : base("B", Id, name, price, quantity)
        {

        }
    }
}
