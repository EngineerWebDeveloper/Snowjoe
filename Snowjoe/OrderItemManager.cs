using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowjoe
{
    public class OrderItemManager
    {
        private List<Item> Items = new List<Item>();
        private List<Order> Orders = new List<Order>();
        public List<Item> GetItems   
        {
            get => Items;
            
        }
        public List<Order> GetOrders
        {
            get => Orders;

        }
        /// <summary>
        /// Inserts an item into the collection if it doesn’t exist.
        /// </summary>
        /// <param name="itemToAdd">Item object to add</param>
        public void AddItem(Item itemToAdd)
        {
            Item itemExist = this.Items.Where(item => item.ItemNumber == itemToAdd.ItemNumber).FirstOrDefault();
            if (itemExist == null)
            {
                this.Items.Add(itemToAdd);
            }
            
        }
        /// <summary>
        /// Removes an item from the collection and removes every order of this item.
        /// </summary>
        /// <param name="ItemNumber"> item number to remove</param>
        public void RemoveItem(string ItemNumber)
        {
            Item itemToRemove = this.Items.Where(item => item.ItemNumber == ItemNumber).FirstOrDefault();
            Items.Remove(itemToRemove);
        }
        /// <summary>
        /// Inserts a deal Item into the collection.
        /// </summary>
        /// <param name="deal">Deal to add to the item</param>
        public void AddDeal(DealItem deal)
        {
            this.RemoveItem(deal.ItemNumber);
            this.AddItem(deal);
        }
        /// <summary>
        /// Inserts an order into the collection if the quantity ordered can be fulfilled
        /// </summary>
        /// <param name="orderToAdd"> Order object to add</param>
        public void AddOrder(Order orderToAdd)
        {
            Item item = this.Items.Where(it => it.ItemNumber == orderToAdd.ItemNumber).FirstOrDefault();
            if (orderToAdd.QuantityOrdered <= item.AvailableQuatity)
            {
                this.Orders.Add(orderToAdd);
                item.AvailableQuatity = item.AvailableQuatity - orderToAdd.QuantityOrdered;
                if (item is Item)
                {
                    this.AddItem(item);
                }
                else
                {
                    this.AddDeal((DealItem)item);
                }
            }
        }
        /// <summary>
        /// Calculates the profit of the existing orders in the collection
        /// </summary>
        public decimal GetProfitLoss()
        {
            decimal profitLoss = 0.0M;
            foreach (Order or in Orders)
            {
                DealItem item = (DealItem)this.Items.Where(it => it.ItemNumber == or.ItemNumber).FirstOrDefault();
                int orderDateAfterStart = DateTime.Compare(item.StartDate.Value, or.OrderDate);
                int orderDateBeforeEnd = DateTime.Compare(or.OrderDate, item.EndDate.Value);

                item.Discount = item.Discount != null && orderDateAfterStart <= 0 && orderDateBeforeEnd <= 0 ? item.Discount : 0;
                profitLoss = profitLoss + ((item.Price * 20 / 100) - (item.Price * (item.Discount ?? 0) / 100)) * or.QuantityOrdered;
            }
            return profitLoss;
        }
    }

}
