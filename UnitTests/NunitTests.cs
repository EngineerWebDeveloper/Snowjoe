using NUnit.Framework;
using Snowjoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    class SnowJoeTests
    {
        [Test]
        public void TestAddItem()
        {
            OrderItemManager or = new OrderItemManager();
            or.AddItem(new Item("12", 12, 30.0m));
            or.AddItem(new Item("13", 14, 24.0m));
            or.AddItem(new Item("13", 14, 25.0m));

            Assert.AreEqual(or.GetItems.Count(), 2);
        }
        [Test]
        public void TestRemoveItem()
        {
            OrderItemManager or = new OrderItemManager();
            or.AddItem(new Item("12", 12, 30.0m));
            or.AddItem(new Item("13q", 14, 24.0m));
            or.RemoveItem("13q");

            Assert.AreEqual(or.GetItems.Count(), 1);
        }
        [Test]
        public void TestAddDeal()
        {
            OrderItemManager or = new OrderItemManager();
            or.AddItem(new Item("13", 14, 24.0m));
            or.AddDeal(new DealItem(2.0m, new DateTime(2002, 10, 18), new DateTime(2002, 10, 19), "13", 14, 24.0m));
            DealItem deal = (DealItem)or.GetItems.First();

            Assert.IsNotNull(deal.StartDate);
        }
        [Test]
        public void TestAddOrder()
        {
            OrderItemManager om = new OrderItemManager();
            om.AddItem(new Item("13", 14, 24.0m));
            om.AddOrder(new Order(new DateTime(2002, 10, 18), "13", 12));
            Assert.AreEqual(om.GetItems.First().AvailableQuatity,2);
        }
        [Test]
        public void GetProfitLoss()
        {
            OrderItemManager om = new OrderItemManager();
            Assert.AreEqual(om.GetProfitLoss(), 0);
            om.AddItem(new Item("13", 14, 24.0m));
            om.AddDeal(new DealItem(2.0m, new DateTime(2002, 10, 18), new DateTime(2002, 10, 19), "13", 14, 24.0m));
            om.AddOrder(new Order(new DateTime(2002, 10, 18), "13", 12));

            Assert.AreEqual(om.GetProfitLoss(), 51.84);
        }
        public static void Main(string[] args)
        { }

        }
}
