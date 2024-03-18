using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParseTry.Collector;
using ParseTry.DBWorker;


namespace ParseTry.MarketParser
{
    public class ParserMarket : IDisposable
    {
        public HttpClient HttpClient { get; set; }
        public string Url { get; set; } = "https://market.csgo.com/api/v2/prices/class_instance/RUB.json";
        public ApplicationContext dataBase { get; set; }
        const string MarketUrl = "https://market-old.csgo.com/item/";
        public List<ItemMarket> marketItems = new List<ItemMarket>();
        public ParserMarket()
        {
            HttpClient = new HttpClient();
        }

        public void Parse()
        {
            var data = HttpClient.GetStringAsync(Url).Result;
            JObject.Parse(data).TryGetValue("items", out JToken items);
            data = null; // очистка
            if (items != null)
            {
                foreach (var item in items)
                {
                    ItemMarket skin = JsonConvert.DeserializeObject<ItemMarket>(item.First.ToString()); //Десериализация данных каждого предмета
                    skin.Id = item.Path; //Использование id предмета в качестве id в представлении БД
                    skin.url = string.Concat(MarketUrl, item.Path.Split('.')?.Last()?.Replace('_', '-'));
                    marketItems.Add(skin);
                }
                items = null; // очистка  
            }
            SortItems();
        }



        public void SortItems()
        {
            var itemSort = marketItems.GroupBy(item => item.market_hash_name);
            var itemsResultSort = new List<ItemMarket>();
            foreach (var itemsInfo in itemSort)
            {
                var newItem = TrasnformItemInfo(itemsInfo);
                itemsResultSort.Add(newItem);
            }
            SaveItemsToDB(itemsResultSort);
            itemSort = null; // очистка
            itemsResultSort = null; // очистка
        }

        private static ItemMarket TrasnformItemInfo(IGrouping<string?, ItemMarket> itemsInfo)
        {
            var skinInfo = new ItemMarket();
            skinInfo.market_hash_name = itemsInfo.Key;
            skinInfo.ru_name = itemsInfo.First().ru_name;
            skinInfo.ru_quality = itemsInfo.First().ru_quality;
            skinInfo.ru_rarity = itemsInfo.First().ru_rarity;
            skinInfo.url = itemsInfo.First().url;
            skinInfo.Id = itemsInfo.First().Id;
            skinInfo.price = itemsInfo.First().price;
            skinInfo.buy_order = itemsInfo.First().buy_order;
            skinInfo.popularity_7d = itemsInfo.First().popularity_7d ?? 0;
            foreach (var skin in itemsInfo)
            {
                skinInfo.price = skin.price < skinInfo.price ? skin.price : skinInfo.price;
                skinInfo.buy_order = skin.buy_order < skinInfo.buy_order ? skin.buy_order : skinInfo.buy_order;
                skinInfo.avg_price = skin.avg_price ?? skinInfo.avg_price;
                skinInfo.popularity_7d += skin.popularity_7d ?? 1;
            }
            return skinInfo;
        }

        private void SaveItemsToDB(List<ItemMarket> items)
        {
            using (dataBase = new ApplicationContext())
            {
                DBworker.UpdateDb(dataBase, items);
            }
        }
        public void Dispose()
        {
            marketItems = null; // очистка 
        }
    }
}
