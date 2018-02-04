using System;

namespace GildedRose.Console.Strategy
{
    public class Cheese:IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            if (item.SellIn >= 0)
            {
                item.Quality++;
            }
            else
            {
                item.Quality += 2;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}
