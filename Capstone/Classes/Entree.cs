using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Entree : CateringItem
    {
        public Entree(string Id, string name, decimal price, int quantity) : base("E", Id, name, price, quantity)
        {

        }


    }

}
