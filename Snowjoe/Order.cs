using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowjoe
{
    public class Order
    {
        public Order(DateTime OrderDate, string ItemNumber, int QuantityOrdered)
        {
            this.OrderDate = OrderDate;
            this.ItemNumber = ItemNumber;
            this.QuantityOrdered = QuantityOrdered;
        }
        public DateTime OrderDate { get; set; }
        public string ItemNumber { get; set; }
        public int QuantityOrdered { get; set; }
    }

}
