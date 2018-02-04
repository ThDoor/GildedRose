using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Test
{
    public class UpdateQualityShould
    {
        private string legendary = "Sulfuras, Hand of Ragnaros";
        private string concert = "Backstage passes to a TAFKAL80ETC concert";
        private string cheese = "Aged Brie";

        private string any = "Any other item";


        [Fact]
        public void NotUpdateQualityOnLegendary()
        {
            //arrange
            int sellIn = 0;
            int quality = 80;

            var items = new List<Item> { new Item { Name = legendary, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality, items[0].Quality);
        }
        [Fact]
        public void NotUpdateSellInOnLegendary()
        {
            //arrange
            int sellIn = 0;
            int quality = 80;

            var items = new List<Item> { new Item { Name = legendary, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(sellIn, items[0].SellIn);
        }
        [Fact]
        public void DecreaseQualityOfConcertToZeroWhenSellInLe0()
        {
            //arrange
            int sellIn = 0;
            int quality = 25;

            var items = new List<Item> { new Item { Name = concert, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(0, items[0].Quality);
            Assert.Equal(sellIn-1, items[0].SellIn);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(15)]
        public void IncreaseQualityOfConcertByOneWhenSellInGt10(int sellIn)
        {
            //arrange
            int quality = 25;

            var items = new List<Item> { new Item { Name = concert, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality+1, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void IncreaseQualityOfConcertByTwoWhenSellInBt10And5(int sellIn)
        {
            //arrange
            int quality = 25;

            var items = new List<Item> { new Item { Name = concert, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality + 2, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void IncreaseQualityOfConcertByTwoWhenSellInLe5(int sellIn)
        {
            //arrange
            int quality = 25;

            var items = new List<Item> { new Item { Name = concert, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality + 3, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        public void NotIncreaseQualityOfConcertWhenQualityIsGe50(int sellIn)
        {
            int quality = 50;
            //arrange            
            var items = new List<Item> { new Item { Name = concert, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        public void IncreaseQualityOfCheeseByOneWhenSellInGt0(int sellIn)
        {
            //arrange
            int quality = 25;

            var items = new List<Item> { new Item { Name = cheese, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality + 1, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void IncreaseQualityOfCheeseByTwoWhenSellInle0(int sellIn)
        {
            //arrange
            int quality = 25;

            var items = new List<Item> { new Item { Name = cheese, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality + 2, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            var items = new List<Item> { new Item { Name = cheese, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }


        [Theory]
        [InlineData(15)]
        [InlineData(7)]
        [InlineData(2)]
        public void DecreaseQualityOfAnyWithOneWhenSellInGt0(int sellIn)
        {
            int quality = 25;
            //arrange            
            var items = new List<Item> { new Item { Name = any, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality-1, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void DecreaseQualityOfAnyWithTwoWhenSellInLt1(int sellIn)
        {
            int quality = 25;
            //arrange            
            var items = new List<Item> { new Item { Name = any, SellIn = sellIn, Quality = quality } };
            var sut = new Inventory();

            //act
            sut.UpdateQuality(items);

            //assert
            Assert.Equal(quality - 2, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }
    }
}
