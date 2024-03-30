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
            //using (var marketParser = new ParserMarket())
            //{
            //    marketParser.Parse();
            //}

            //CollectorClass.AggressiveCollectAllGen();

            var buffprsr = new ParserBuff(1, 3, "session=1-JtWI5txpxqjGtRcZjTLaDmSfGs2MictS4IRPyPhLgncV2038218285"); // добавить парсинг курса юаня
            buffprsr.TryParseInitialization();

            TransformClass.TransformToResult();
        }
    }
}