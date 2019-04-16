using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowjoe
{
    public class DealItem : Item
    {
        public DealItem(decimal Discount, DateTime StartDate, DateTime EndDate, string ItemNumber, int AvailableQuatity, Decimal Price) : base(ItemNumber, AvailableQuatity, Price)
        {
            this.Discount = Discount;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public DealItem(string ItemNumber, int AvailableQuatity, Decimal Price) : base(ItemNumber, AvailableQuatity, Price)
        {
            this.Discount = null;
            this.StartDate = null;
            this.EndDate = null;
        }
        public decimal? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
