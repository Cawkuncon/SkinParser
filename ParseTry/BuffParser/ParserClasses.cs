using System.ComponentModel.DataAnnotations;

namespace ParseTry.BuffParser
{
    public class Root
    {
        public decimal buy_max_price { get; set; }
        public int buy_num { get; set; }
        public GoodsInfo goods_info { get; set; }
        public string id { get; set; }
        public string market_hash_name { get; set; }
        public decimal quick_price { get; set; }
        public decimal sell_min_price { get; set; }
        public int sell_num { get; set; }
        public string steam_market_url { get; set; }
    }
    public class GoodsInfo
    {
        public Info info { get; set; }
        public string original_icon_url { get; set; }
        public decimal steam_price { get; set; }
        public decimal steam_price_cny { get; set; }
    }

    public class Info
    {
        public Tags tags { get; set; }
    }
    public class Tags
    {
        public Exterior? exterior { get; set; }
        public Type type { get; set; }
    }


    public class Exterior
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class Type
    {
        public string category { get; set; }
        public int id { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }
}
