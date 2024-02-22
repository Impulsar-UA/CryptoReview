using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.Model
{
    public class AssetHistoryEntry
    {
        public decimal PriceUsd { get; set; }
        public DateTimeOffset Time { get; set; }
    }
    public class AssetHistory
    {
        public List<AssetHistoryEntry> Data { get; set; }
    }
}
