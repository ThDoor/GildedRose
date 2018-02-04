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
        public void DescreaseSellInByOne(int sellIn)
        {
            //arrange
            var item = new Item{ Name = "n/a", Quality = 0, SellIn = sellIn };
            var sut = new StandardDecreasing();
            
            //act
            sut.UpdateQuality(item);

            //assert
            Assert.Equal(sellIn-1,item.SellIn);
        }
    }
}
