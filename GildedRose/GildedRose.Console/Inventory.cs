using System.Collections.Generic;
using GildedRose.Console.Strategy;

namespace GildedRose.Console
{
    public class Inventory : IInventory
    {
        private readonly IUpdateQualityStrategyFactory _factory;
        public Inventory(IUpdateQualityStrategyFactory factory)
        {
            _factory = factory;
        }

        public void UpdateQuality(IList<Item> items)
        {            
            foreach (var item in items)
            {
                _factory.Create(item.Name).UpdateQuality(item);
            }
        }
    }
}