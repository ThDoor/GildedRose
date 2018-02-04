using GildedRose.Console;
using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class LegendaryShould
    {
        [Fact]
        public void NotUpdateLegendary()
        {
            //arrange
            int sellIn = 0;
            int quality = 80;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality } ;
            var sut = new Legendary();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn, item.SellIn);
            Assert.Equal(quality, item.Quality);
        }
    }
}
