using GildedRose.Console;
using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class ConjuredShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseSellInByOne(int sellIn)
        {
            //arrange
            var item = new Item { Name = "n/a", Quality = 0, SellIn = sellIn };
            var sut = new Conjured();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn - 1, item.SellIn);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(2)]
        [InlineData(1)]
        public void DecreaseQualityByTwoWhenSellInGt0(int sellIn)
        {
            //arrange
            int quality = 10;

            var item = new Item { Name = "n/a", Quality = quality, SellIn = sellIn };
            var sut = new Conjured();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality - 2, item.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void NotDecreaseQualityBellow0(int sellIn)
        {
            //arrange
            int quality = 2;
            int expectedQuality = 0;

            var item = new Item { Name = "n/a", Quality = quality, SellIn = sellIn };
            var sut = new Conjured();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void DecreaseQualityByFourWhenSellInLt1(int sellIn)
        {
            //arrange
            int quality = 10;

            var item = new Item { Name = "n/a", Quality = quality, SellIn = sellIn };
            var sut = new Conjured();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality - 4, item.Quality);
        }
    }
}
