using GildedRose.Console;
using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class TicketShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-5)]
        public void DecreaseSellInByOne(int sellIn)
        {
            //arrange
            var item = new Item { Name = "n/a", Quality = 0, SellIn = sellIn };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn - 1, item.SellIn);
        }

        [Fact]
        public void DecreaseQualityOfTicketToZeroWhenSellInLt1()
        {
            //arrange
            int sellIn = 0;
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(15)]
        public void IncreaseQualityOfTicketByOneWhenSellInGt10(int sellIn)
        {
            //arrange
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality + 1, item.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void IncreaseQualityOfTicketByTwoWhenSellInBt10And5(int sellIn)
        {
            //arrange
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality + 2, item.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void IncreaseQualityOfTicketByThreeWhenSellInLe5(int sellIn)
        {
            //arrange
            int quality = 25;

            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality + 3, item.Quality);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        public void NotIncreaseQualityOfTicketWhenQualityIsGe50(int sellIn)
        {
            int quality = 50;
            //arrange            
            var item = new Item { Name = "n/a", SellIn = sellIn, Quality = quality };
            var sut = new Ticket();

            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(quality, item.Quality);
        }
    }
}
