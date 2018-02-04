namespace GildedRose.Console.Strategy
{
    public class Conjured:IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            if (item.SellIn >= 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality -= 4;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

        }
    }
}
