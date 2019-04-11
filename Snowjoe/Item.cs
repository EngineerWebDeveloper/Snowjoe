using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowjoe
{
    internal class Item
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

    internal class DealItem:Item
    {
        public DealItem(decimal Discount, DateTime StartDate, DateTime EndDate,string ItemNumber, int AvailableQuatity, Decimal Price):base(ItemNumber, AvailableQuatity,Price)
        {
            this.Discount = Discount;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public DealItem( string ItemNumber, int AvailableQuatity, Decimal Price) : base(ItemNumber, AvailableQuatity, Price)
        {
            this.Discount = null;
            this.StartDate = null;
            this.EndDate = null;
        }
        public decimal? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    internal class Order
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

    internal class OrderItemManager
    {
        public List<DealItem> Items = new List<DealItem>();
        public List<Order> Orders = new List<Order>();
        public void AddItem(DealItem itemToAdd)
        {
            this.RemoveItem(itemToAdd.ItemNumber);
            this.Items.Add(itemToAdd);
        }
        public void RemoveItem(string ItemNumber)
        {
            DealItem itemToRemove = this.Items.Where(item => item.ItemNumber == ItemNumber).FirstOrDefault();
            Items.Remove(itemToRemove);
        }
        public void AddDeal(DealItem deal)
        {
            this.RemoveItem(deal.ItemNumber);
            this.AddItem(deal);
        }
        public void AddOrder(Order orderToAdd)
        {
            DealItem item = this.Items.Where(it => it.ItemNumber == orderToAdd.ItemNumber).FirstOrDefault();
            if(orderToAdd.QuantityOrdered <= item.AvailableQuatity)
            {
                this.Orders.Add(orderToAdd);
                item.AvailableQuatity = item.AvailableQuatity-orderToAdd.QuantityOrdered;
                if(item is Item)
                {
                    this.AddItem(item);
                }
                else
                {
                    this.AddDeal(item);
                }
            }
        }

        public decimal GetProfitLoss()
        {
            decimal profitLoss = 0.0M;
            foreach(Order or in Orders)
            {
                var item = this.Items.Where(it => it.ItemNumber == or.ItemNumber).FirstOrDefault();
                profitLoss = profitLoss + ((item.Price * 20 / 100) - (item.Price * (item.Discount ?? 0) / 100)) * or.QuantityOrdered;
            }
            return profitLoss;
        }
    }
    class Program
    {
        public static void  Main(string[] args)
        {
            OrderItemManager OM = new OrderItemManager();
            OM.AddItem(new DealItem("12", 12, 30.0M));
            OM.AddItem(new DealItem("13", 14, 24.0M));
            //decimal Discount, DateTime StartDate, DateTime EndDate,string ItemNumber, int AvailableQuatity, Decimal Price
            OM.AddDeal(new DealItem(2.0M, new DateTime(2002, 10, 18),new DateTime(2002, 10, 19),"13", 14, 24.0M));
            OM.AddOrder(new Order(new DateTime(2002, 10, 18), "13", 12));
            Console.WriteLine(OM.GetProfitLoss());
           // foreach (Item i in OM.Items)
           // {
               // Console.WriteLine(i);
            //}
            Console.ReadKey();
        }
    }
}
