namespace GildedRose.Console.Strategy
{
    public interface IUpdateQualityStrategyFactory
    {
        IUpdateQualityStrategy Create(string name);
    }
}
