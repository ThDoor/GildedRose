using GildedRose.Console;
using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class StandardDecreasingShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseSellInByOne(int sellIn)
        {
            //arrange
            var item = new Item{ Name = "n/a", Quality = 0, SellIn = sellIn };
            var sut = new StandardDecreasing();
            
            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn-1,item.SellIn);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(2)]
        [InlineData(1)]
         public void DecreaseQualityByOneWhenSellInGt0(int sellIn)
        {
            //arrange
            int quality = 10;

            var item = new Item { Name = "n/a", Quality = quality, SellIn = sellIn };
            var sut = new StandardDecreasing();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality-1,item.Quality);
        }

    }
}
