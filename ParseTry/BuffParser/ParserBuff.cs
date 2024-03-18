using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParseTry.DBWorker;

namespace ParseTry.BuffParser
{
    internal class ParserBuff
    {
        private HttpClient HttpClient { get; set; }
        private string Session { get; set; }
        private ApplicationContext dataBase { get; set; }
        private Uri uri { get; set; }
        private string UrlToParse { get; set; }
        private const string Url = "https://buff.163.com/api/market/goods?game=csgo&page_num=";
        private decimal minPrice { get; set; }
        private decimal maxPrice { get; set; }
        private int TotalPages { get; set; }

        public ParserBuff(decimal minPrice, decimal maxPrice, string session)
        {
            HttpClient = new HttpClient();
            this.maxPrice = maxPrice > minPrice ? maxPrice : minPrice;
            this.minPrice = minPrice < maxPrice ? minPrice : maxPrice;
            Session = session;
            ConcatUrl(100000);
            HttpClient.DefaultRequestHeaders.Add("cookie", Session);
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
                };
            }
        }


        private JObject GetParseResponse()
        {
            while (true)
            {
                try
                {
                    return JObject.Parse(HttpClient.GetStringAsync(uri).Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Ожидание 5 сек");
                    Thread.Sleep(5000);
                }
            }
        }

        private void ConsoleProcents(int i)
        {
            Console.Clear();
            var percents = Math.Round(((double)i / TotalPages) * 100, 2);
            Console.WriteLine(percents + "%");
        }
        private ItemBuff MapDeserializedToDataBase(Root skinInfo)
        {
            var SkinInfoToSaveDB = new ItemBuff
            {
                Id = skinInfo.id,
                buy_max_price = skinInfo.buy_max_price,
                buy_num = skinInfo.buy_num,
                original_icon_url = skinInfo.goods_info.original_icon_url,
                steam_price = skinInfo.goods_info.steam_price,
                steam_price_cny = skinInfo.goods_info.steam_price_cny,
                market_hash_name = skinInfo.market_hash_name,
                quick_price = skinInfo.quick_price,
                sell_min_price = skinInfo.sell_min_price,
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
    }
}
