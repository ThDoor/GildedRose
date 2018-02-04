using GildedRose.Console;
using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class CheeseShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseSellInByOne(int sellIn)
        {
            //arrange
            var item = new Item { Name = "n/a", Quality = 0, SellIn = sellIn };
            var sut = new StandardDecreasing();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn - 1, item.SellIn);
        }


        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        public void IncreaseQualityOfCheeseByOneWhenSellInGt0(int sellIn)
        {
            //arrange
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Cheese();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality + 1, item.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void IncreaseQualityOfCheeseByTwoWhenSellInle0(int sellIn)
        {
            //arrange
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Cheese();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality + 2, item.Quality);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void NotIncreaseQualityOfCheeseWhenQualityIsGe50(int sellIn)
        {
            int quality = 50;
            //arrange            
            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Cheese();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality, item.Quality);
        }
    }
}
