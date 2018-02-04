using System;

namespace GildedRose.Console.Strategy
{
    public class StandardDecreasing : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            if (item.SellIn >= 0)
            {
                item.Quality--;
            }
        }
    }
}
