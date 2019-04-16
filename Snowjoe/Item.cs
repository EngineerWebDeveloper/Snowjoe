using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowjoe
{
    public class Item
    {
        public Item(string ItemNumber, int AvailableQuatity, Decimal Price)
        {
            this.ItemNumber = ItemNumber;
            this.AvailableQuatity = AvailableQuatity;
            this.Price = Price;
        }
        public string ItemNumber { get; set; }
        public int AvailableQuatity { get; set; }
        public Decimal Price { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
        
        }
    }
}
