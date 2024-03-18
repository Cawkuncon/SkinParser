using System.ComponentModel.DataAnnotations;

namespace ParseTry.BuffParser
{
    public class ItemBuff
    {
        [Key]
        public string Id { get; set; }
        public decimal buy_max_price { get; set; }
        public int buy_num { get; set; }
        public string original_icon_url { get; set; }
        public decimal steam_price { get; set; }
        public decimal steam_price_cny { get; set; }
        public string market_hash_name { get; set; }
        public decimal quick_price { get; set; }
        public decimal sell_min_price { get; set; }
        public int sell_num { get; set; }
        public string steam_market_url { get; set; }
        public string? exterior_localized_name { get; set; }
        public string type_localized_name { get; set; }
        public string url_buff { get; set; }

        //public override bool Equals(object? obj)
        //{
        //    if (obj is ItemBuff) return Id == ((ItemBuff)obj).Id;
        //    return false;
        //}
        //public override int GetHashCode() => Id.GetHashCode();
    }
}
