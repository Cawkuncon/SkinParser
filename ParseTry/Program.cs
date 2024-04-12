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

            Console.WriteLine("Начало работы парсера по маркету");
            using (var marketParser = new ParserMarket())
            {
                marketParser.Parse();
            }
			Console.WriteLine("Конец работы парсера по маркету");

			CollectorClass.AggressiveCollectAllGen();

            Console.WriteLine("Введите код сессии");
            var session = Console.ReadLine();
            Console.WriteLine("Введите минимальную цену в юанях");
            var minPrice = decimal.Parse(Console.ReadLine());
			Console.WriteLine("Введите максимальную цену в юанях");
            var maxPrice = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Начало работы парсера по баффу");
            var buffprsr = new ParserBuff(minPrice, maxPrice, $"session={session}"); //минимальная цена поиска предметов в Юанях, максимальная цена в Юанях, код сессии
            buffprsr.TryParseInitialization();
			Console.WriteLine("Конец работы парсера по баффу");

			TransformClass.TransformToResult();
        }
    }
}