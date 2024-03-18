using ParseTry.BuffParser;
using ParseTry.Collector;
using ParseTry.Main;
using ParseTry.MarketParser;

namespace ParseTry
{

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var marketParser = new ParserMarket())
            {
                marketParser.Parse();
            }

            CollectorClass.AggressiveCollectAllGen();

            var buffprsr = new ParserBuff(1, 1000, "session=1-RvhomA9t4RqcLTxzCL8_5tWv_4rWsQkHRr1uOXTQ3Kxu2038218285");
            buffprsr.TryParseInitialization();

            TransformClass.TransformToResult();
        }
    }
}