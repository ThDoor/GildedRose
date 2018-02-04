using System.Collections.Generic;

namespace GildedRose.Console
{
    public interface IInventory
    {
        void UpdateQuality(IList<Item> items);
    }
}