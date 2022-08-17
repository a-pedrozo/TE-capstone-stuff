using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Dessert : CateringItem
    {
        public Dessert(string Id, string name, decimal price, int quantity) : base("D", Id, name, price, quantity)
        {

        }
    }
}
