using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParseTry.Collector;
using ParseTry.DBWorker;
using ParseTry.Main;

namespace ParseTry.BuffParser
{
    internal class ParserBuff
    {
        private HttpClient UserHttpClient { get; set; }
        private string Session { get; set; }
        private ApplicationContext dataBase { get; set; }
        private Uri uri { get; set; }
        private string UrlToParse { get; set; }
        private const string Url = "https://buff.163.com/api/market/goods?game=csgo&page_num=";
        private decimal minPrice { get; set; }
        private decimal maxPrice { get; set; }
        private int TotalPages { get; set; }
        private Random random { get; set; }

        public ParserBuff(decimal minPrice, decimal maxPrice, string session)
        {
            HttpClientInitialization();
            random = new Random();
            this.maxPrice = maxPrice > minPrice ? maxPrice : minPrice;
            this.minPrice = minPrice < maxPrice ? minPrice : maxPrice;
            Session = session;
            ConcatUrl(100000);
            UserHttpClient.DefaultRequestHeaders.Add("cookie", Session);
        }

        public void TryParseInitialization()
        {
            var parseInfo = GetParseResponse();
            parseInfo.TryGetValue("code", out JToken code);
            if (code.ToString() != "OK")
            {
                throw new Exception("Не удалось установить соединение или неверные параметры");
            }
            else
            {
                TotalPages = parseInfo["data"]["total_page"].Value<int>();
            }
            Parse();
        }

        public void Parse()
        {
            for (int page = 1; page <= TotalPages; page++)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    ConcatUrl(page);
                    ConsoleProcents(page);
                    var response = GetParseResponse();
                    var listToSave = new List<ItemBuff>();
                    if (response.TryGetValue("data", out JToken data))
                    {
                        var items = data["items"];
                        foreach (var item in items)
                        {
                            var skinInfo = JsonConvert.DeserializeObject<Root>(item.ToString());
                            ItemBuff infoSkinToSaveDB = MapDeserializedToDataBase(skinInfo);
                            listToSave.Add(infoSkinToSaveDB);
                        }
                    }
                    DBworker.UpdateDb(db, listToSave);
                    Thread.Sleep(1500);
                };
            }
        }


        private JObject GetParseResponse()
        {
            while (true)
            {
                try
                {
                    return JObject.Parse(UserHttpClient.GetStringAsync(uri).Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Ожидание 5 сек");
                    ChangeRandomUserAgent();
                    Thread.Sleep(5000);
                }
            }
        }

        private ItemBuff MapDeserializedToDataBase(Root skinInfo)
        {
            var SkinInfoToSaveDB = new ItemBuff
            {
                Id = skinInfo.id,
                buy_max_price = skinInfo.buy_max_price * ValueСurrency.cnyValue,
                buy_num = skinInfo.buy_num,
                original_icon_url = skinInfo.goods_info.icon_url,
                steam_price = skinInfo.goods_info.steam_price,
                steam_price_cny = skinInfo.goods_info.steam_price_cny * ValueСurrency.cnyValue,
                market_hash_name = skinInfo.market_hash_name,
                quick_price = skinInfo.quick_price,
                sell_min_price = skinInfo.sell_min_price * ValueСurrency.cnyValue,
                sell_num = skinInfo.sell_num,
                steam_market_url = skinInfo.steam_market_url,
                exterior_localized_name = skinInfo.goods_info.info.tags.exterior?.localized_name,
                type_localized_name = skinInfo.goods_info.info.tags.type.localized_name,
                url_buff = string.Concat("https://buff.163.com/goods/", skinInfo.id)
            };
            return SkinInfoToSaveDB;
        }
        private void ConcatUrl(int page_num)
        {
            UrlToParse = string.Concat(Url, page_num, "&min_price=", minPrice, "&max_price=", maxPrice, "&page_size=80");
            uri = new Uri(UrlToParse);
        }
        private void ChangeRandomUserAgent()
        {
            var randUserAgent = random.Next(UserAgentsClass.userAgents.Count);
            UserHttpClient.DefaultRequestHeaders.Add("User-Agent", UserAgentsClass.userAgents[randUserAgent]);
        }

        private void ConsoleProcents(int i)
        {
            Console.Clear();
            var percents = Math.Round(((double)i / TotalPages) * 100, 2);
            Console.WriteLine(percents + "%");
        }

        private void HttpClientInitialization()
        {
            UserHttpClient = new HttpClient();
            UserHttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 OPR/108.0.0.0");
            UserHttpClient.DefaultRequestHeaders.Add("Accept", @"*/*");
            UserHttpClient.DefaultRequestHeaders.Add("Accept-Encoding", "*");
            UserHttpClient.DefaultRequestHeaders.Add("Accept-Language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
        }
    }
}
