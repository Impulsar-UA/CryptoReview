using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.Model
{   public class Market
    {
        public string ExchangeId { get; set; }
        public string Rank { get; set; }
        public string BaseSymbol { get; set; }
        public string BaseId { get; set; }
        public string QuoteSymbol { get; set; }
        public string QuoteId { get; set; }
        public double PriceQuote { get; set; }
        public double? PriceUsd { get; set; }
        public double? VolumeUsd24Hr { get; set; }
        public double? PercentExchangeVolume { get; set; }
        public int? TradesCount24Hr { get; set; }
        public long Updated { get; set; }
    }
    public class MarketsData
    {
        public List<Market> Data { get; set; }
    }
}
