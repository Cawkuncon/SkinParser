using ParseTry.BuffParser;
using ParseTry.Collector;
using ParseTry.Main;
using ParseTry.MarketParser;
using System.Globalization;


namespace ParseTry
{

    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            //using (var marketParser = new ParserMarket())
            //{
            //    marketParser.Parse();
            //}

            //CollectorClass.AggressiveCollectAllGen();

            //var buffprsr = new ParserBuff(10, 1000, "session=1-7mRPd4lMTC9bvRExKhY6OIoEIN5EOMTirTDSmQMdiH6G2038218285"); // добавить парсинг курса юаня
            //buffprsr.TryParseInitialization();

            TransformClass.TransformToResult();
        }
    }
}