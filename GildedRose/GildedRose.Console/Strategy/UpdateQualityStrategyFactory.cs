namespace GildedRose.Console.Strategy
{
    public class UpdateQualityStrategyFactory : IUpdateQualityStrategyFactory
    {
        public IUpdateQualityStrategy Create(string name)
        {
            IUpdateQualityStrategy strategy;

            switch (Convert(name))
            {
                case ItemType.Legendary:
                    strategy = new Legendary();
                    break;
                case ItemType.Cheese:
                    strategy = new Cheese();
                    break;
                case ItemType.Ticket:
                    strategy = new Ticket();
                    break;
                case ItemType.Conjured:
                    strategy = new Conjured();
                    break;
                default:
                    strategy = new StandardDecreasing();
                    break;
            }          
            return strategy;
        }

        private ItemType Convert(string name)
        {
            ItemType result;
            switch (name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    result = ItemType.Legendary;
                    break;
                case "Aged Brie":
                    result = ItemType.Cheese;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    result = ItemType.Ticket;
                    break;
                case "Conjured Mana Cake":
                    result = ItemType.Conjured;
                    break;
                default:
                    result = ItemType.Standard;
                    break;
            }
            return result;
        }
    }

    public enum ItemType
    {
        Legendary,
        Cheese,
        Ticket,
        Conjured,
        Standard
    }
}
