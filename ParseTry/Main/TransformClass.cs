using ParseTry.BuffParser;
using ParseTry.DBWorker;
using ParseTry.MarketParser;
using System.Collections.Generic;

namespace ParseTry.Main
{
    public static class TransformClass
    {
        public static void TransformToResult()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var listBuff = db.BuffItems.ToList();
                var listMarket = db.Items.ToList();
                var resultItems = new List<ResultItem>();
                foreach (var item in listBuff)
                {
                    var marketItem = listMarket.FirstOrDefault(skin => skin.market_hash_name == item.market_hash_name);
                    if (marketItem != null)
                    {
                        ResultItem itemToSave = MapToResultItem(item, marketItem);
                        resultItems.Add(itemToSave);
                    }
                }
                DBworker.UpdateDb(db, resultItems);
            }
        }

        private static ResultItem MapToResultItem(ItemBuff buffItem, ItemMarket marketItem)
        {
            Dictionary<string, decimal> newDictDivPrices = GetDivisionPrices(buffItem, marketItem);
            ResultItem resultItem = new ResultItem()
            {
                hash_name = buffItem.market_hash_name,
                market_buy_order = marketItem.buy_order,
                buff_buy_max_price = buffItem.buy_max_price,
                market_price = marketItem.price,
                buff_sell_min_price = buffItem.sell_min_price,
                buff_steam_price_cny = buffItem.steam_price_cny,
                buff_buy_num = buffItem.buy_num,
                buff_sell_num = buffItem.sell_num,
                pricesBM = newDictDivPrices.GetValueOrDefault("B/M"),
                pricesMB = newDictDivPrices.GetValueOrDefault("M/B"),
                pricesSM = newDictDivPrices.GetValueOrDefault("S/M"),
                pricesMS = newDictDivPrices.GetValueOrDefault("M/S"),
                pricesSB = newDictDivPrices.GetValueOrDefault("S/B"),
                pricesBS = newDictDivPrices.GetValueOrDefault("B/S"),
                market_popularity_7d = marketItem.popularity_7d,
                buff_exterior_localized_name = buffItem.exterior_localized_name,
                buff_type_localized_name = buffItem.type_localized_name,
                buff_url_buff = buffItem.url_buff,
                market_url = marketItem.url,
                buff_steam_market_url = buffItem.steam_market_url,
                buff_original_icon_url = buffItem.original_icon_url,
            };
            return resultItem;
        }

        private static Dictionary<string, decimal> GetDivisionPrices(ItemBuff buffItem, ItemMarket marketItem)
        {//ЦЕНЫ В РАЗНОЙ ВАЛЮТЕ!!!!!!!!!!!
            Dictionary<string, decimal> resultDict = new Dictionary<string, decimal>();
            var BM = buffItem.sell_min_price == 0 ? 0 : (marketItem.price * (decimal)0.95) / buffItem.sell_min_price; 
            var MB = (buffItem.sell_min_price * (decimal)0.975) / marketItem.price;
			var SM = (marketItem.price * (decimal)0.95) / buffItem.steam_price_cny; 
            var MS = (buffItem.steam_price_cny * (decimal)0.87) / marketItem.price;
            var SB = (buffItem.sell_min_price * (decimal)0.975) / buffItem.steam_price_cny;
			var BS = buffItem.sell_min_price == 0 ? 0 : (buffItem.steam_price_cny * (decimal)0.87) / buffItem.sell_min_price;
            resultDict.Add("B/M", BM);
            resultDict.Add("M/B", MB);
            resultDict.Add("S/M", SM);
            resultDict.Add("M/S", MS);
            resultDict.Add("S/B", SB);
            resultDict.Add("B/S", BS);
            return resultDict;
        }
    }
}
