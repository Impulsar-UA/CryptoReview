using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.Model
{
    public class Asset
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Supply { get; set; }
        public double? MaxSupply { get; set; }
        public double? MarketCapUsd { get; set; }
        public double? VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
        public double? ChangePercent24Hr { get; set; }
        public double? Vwap24Hr { get; set; }
        public string? Explorer { get; set; }
        public class AssetHistory
        {
            public List<AssetHistoryEntry> Data { get; set; }
            public long Timestamp { get; set; }
        }
    }
    public class AssetHistoryEntry
    {
        public decimal PriceUsd { get; set; }
        public DateTimeOffset Time { get; set; }
    }
    public class AssetsData
    {
        public List<Asset> Data { get; set; }
    }
    public class AssetData
    {
        public Asset Data { get; set; }
    }
}
