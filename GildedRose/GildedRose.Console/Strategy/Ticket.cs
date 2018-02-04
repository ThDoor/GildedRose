using System;

namespace GildedRose.Console.Strategy
{
    public class Ticket:IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            if (item.SellIn >= 10)
            {
                item.Quality++;
            }
            if (item.SellIn >= 5 && item.SellIn < 10 )
            {
                item.Quality += 2;
            }
            if (item.SellIn >= 0 && item.SellIn < 5)
            {
                item.Quality += 3;
            }
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}
