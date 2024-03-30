using ParseTry.BuffParser;
using ParseTry.Main;
using ParseTry.MarketParser;


namespace ParseTry.DBWorker
{
    public static class DBworker
    {
        public static void UpdateDb(ApplicationContext context, List<ItemMarket> items)
        {
            foreach (var item in items)
            {
                var skin = context.Items.FirstOrDefault(skininfo => skininfo.Id == item.Id);
                if (skin != null)
                {
                    skin.price = item.price;
                    skin.buy_order = item.buy_order;
                    skin.popularity_7d = item.popularity_7d;
                }
                else
                {
                    context.Items.Add(item);
                }
            }
            context.SaveChanges();
        }

        public static void UpdateDb(ApplicationContext context, List<ItemBuff> items)
        {
            foreach (var item in items)
            {
                var skin = context.BuffItems.FirstOrDefault(skininfo => skininfo.Id == item.Id);
                if (skin != null)
                {
                    skin.buy_max_price = item.buy_max_price;
                    skin.buy_num = item.buy_num;
                    skin.steam_price_cny = item.steam_price_cny;
                    skin.steam_price = item.steam_price;
                    skin.quick_price = item.quick_price;
                    skin.sell_min_price = item.sell_min_price;
                    skin.sell_num = item.sell_num;
                }
                else
                {
                    try
                    {
                        context.BuffItems.Add(item);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            context.SaveChanges();
        }

        public static void UpdateDb(ApplicationContext contex, List<ResultItem> items)
        {
            foreach (var item in items)
            {
                var skin = contex.ResultItems.FirstOrDefault(skininfo => skininfo.hash_name == item.hash_name);
                if (skin != null)
                {
                    skin.market_buy_order = item.market_buy_order;
                    skin.buff_buy_max_price = item.buff_buy_max_price;
                    skin.market_price = item.market_price;
                    skin.buff_sell_min_price = item.buff_sell_min_price;
                    skin.buff_steam_price_cny = item.buff_steam_price_cny;
                    skin.buff_buy_num = item.buff_buy_num;
                    skin.buff_sell_num = item.buff_sell_num;
                    skin.market_popularity_7d = item.market_popularity_7d;
                }
                else
                {
                    contex.ResultItems.Add(item);
                }
            }
            contex.SaveChanges();
        }
    }
}
