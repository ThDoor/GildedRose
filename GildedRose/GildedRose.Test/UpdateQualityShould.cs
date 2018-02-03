using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Test
{
    public class UpdateQualityShould
    {
        [Fact]
        public void NotUpdateQualityOnLegendary()
        {
            //arrange
            int sellIn = 0;
            int quality = 80;

            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };
            var sut = new Program(items);

            //act
            sut.UpdateQuality();

            //assert
            Assert.Equal(quality, items[0].Quality);
        }
        [Fact]
        public void NotUpdateSellInOnLegendary()
        {
            //arrange
            int sellIn = 0;
            int quality = 80;

            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality } };
            var sut = new Program(items);

            //act
            sut.UpdateQuality();

            //assert
            Assert.Equal(sellIn, items[0].SellIn);
        }
    }
}
