using System.ComponentModel.DataAnnotations;

namespace ParseTry.MarketParser
{
    public class ItemMarket
    {
        [Key]
        public string Id { get; set; }
        public decimal price { get; set; }
        public decimal buy_order { get; set; }
        public decimal? avg_price { get; set; }
        public int? popularity_7d { get; set; }
        public string? market_hash_name { get; set; }
        public string? ru_name { get; set; }
        public string? ru_rarity { get; set; }
        public string? ru_quality { get; set; }
        public string? url { get; set; }
    }
}
