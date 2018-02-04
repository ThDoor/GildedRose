using GildedRose.Console.Strategy;
using Xunit;

namespace GildedRose.Test
{
    public class UpdateQualityStrategyFactoryShould
    {
        [Fact]
        public void ReturnLegendaryWhenItemNameIs()
        {
            var name = "Sulfuras, Hand of Ragnaros";

            var sut = new UpdateQualityStrategyFactory();

            var result = sut.Create(name);

            Assert.IsType<Legendary>(result);
        }
        [Fact]
        public void ReturnCheeseWhenItemNameIs()
        {
            var name = "Aged Brie";

            var sut = new UpdateQualityStrategyFactory();

            var result = sut.Create(name);

            Assert.IsType<Cheese>(result);
        }
        [Fact]
        public void ReturnTicketWhenItemNameIs()
        {
            var name = "Backstage passes to a TAFKAL80ETC concert";

            var sut = new UpdateQualityStrategyFactory();

            var result = sut.Create(name);

            Assert.IsType<Ticket>(result);
        }
        [Fact]
        public void ReturnConjuredWhenItemNameIs()
        {
            var name = "Conjured Mana Cake";

            var sut = new UpdateQualityStrategyFactory();

            var result = sut.Create(name);

            Assert.IsType<Conjured>(result);
        }
        [Fact]
        public void ReturnStandardWhenItemNameIs()
        {
            var name = "any name";

            var sut = new UpdateQualityStrategyFactory();

            var result = sut.Create(name);

            Assert.IsType<StandardDecreasing>(result);
        }
    }
}
