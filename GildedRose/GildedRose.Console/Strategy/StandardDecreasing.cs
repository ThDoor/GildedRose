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

            // never decrease quality below zero
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
