using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using static CryptoReview.Model.Asset;

namespace CryptoReview.Model
{
    public class MyHttpClient
    {
        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            string json = @"
      {
            ""data"": [
                { ""id"": ""bitcoin"", ""rank"": 1, ""symbol"": ""BTC"", ""name"": ""Bitcoin"", ""supply"": 19000000, ""maxSupply"": 21000000, ""marketCapUsd"": 800000000000, ""volumeUsd24Hr"": 30000000000, ""priceUsd"": 42000, ""changePercent24Hr"": 2.5, ""vwap24Hr"": 41500, ""explorer"": ""https://blockchain.com/explorer"" },
                { ""id"": ""ethereum"", ""rank"": 2, ""symbol"": ""ETH"", ""name"": ""Ethereum"", ""supply"": 120000000, ""maxSupply"": null, ""marketCapUsd"": 400000000000, ""volumeUsd24Hr"": 20000000000, ""priceUsd"": 3000, ""changePercent24Hr"": 1.8, ""vwap24Hr"": 2980, ""explorer"": ""https://etherscan.io"" },
                { ""id"": ""tether"", ""rank"": 3, ""symbol"": ""USDT"", ""name"": ""Tether"", ""supply"": 83000000000, ""maxSupply"": null, ""marketCapUsd"": 83000000000, ""volumeUsd24Hr"": 50000000000, ""priceUsd"": 1, ""changePercent24Hr"": 0, ""vwap24Hr"": 1, ""explorer"": ""https://tronscan.io"" },
                { ""id"": ""bnb"", ""rank"": 4, ""symbol"": ""BNB"", ""name"": ""Binance Coin"", ""supply"": 160000000, ""maxSupply"": 200000000, ""marketCapUsd"": 65000000000, ""volumeUsd24Hr"": 1200000000, ""priceUsd"": 400, ""changePercent24Hr"": -0.5, ""vwap24Hr"": 395, ""explorer"": ""https://bscscan.com"" },
                { ""id"": ""solana"", ""rank"": 5, ""symbol"": ""SOL"", ""name"": ""Solana"", ""supply"": 400000000, ""maxSupply"": null, ""marketCapUsd"": 50000000000, ""volumeUsd24Hr"": 1000000000, ""priceUsd"": 125, ""changePercent24Hr"": 3.2, ""vwap24Hr"": 123, ""explorer"": ""https://solscan.io"" },
                { ""id"": ""ripple"", ""rank"": 6, ""symbol"": ""XRP"", ""name"": ""XRP"", ""supply"": 50000000000, ""maxSupply"": 100000000000, ""marketCapUsd"": 30000000000, ""volumeUsd24Hr"": 900000000, ""priceUsd"": 0.6, ""changePercent24Hr"": 0.2, ""vwap24Hr"": 0.59, ""explorer"": ""https://xrpscan.com"" },
                { ""id"": ""cardano"", ""rank"": 7, ""symbol"": ""ADA"", ""name"": ""Cardano"", ""supply"": 35000000000, ""maxSupply"": 45000000000, ""marketCapUsd"": 15000000000, ""volumeUsd24Hr"": 700000000, ""priceUsd"": 0.43, ""changePercent24Hr"": -1.1, ""vwap24Hr"": 0.42, ""explorer"": ""https://cardanoscan.io"" },
                { ""id"": ""dogecoin"", ""rank"": 8, ""symbol"": ""DOGE"", ""name"": ""Dogecoin"", ""supply"": 130000000000, ""maxSupply"": null, ""marketCapUsd"": 18000000000, ""volumeUsd24Hr"": 600000000, ""priceUsd"": 0.14, ""changePercent24Hr"": 0.9, ""vwap24Hr"": 0.139, ""explorer"": ""https://dogechain.info"" },
                { ""id"": ""polkadot"", ""rank"": 9, ""symbol"": ""DOT"", ""name"": ""Polkadot"", ""supply"": 1200000000, ""maxSupply"": null, ""marketCapUsd"": 10000000000, ""volumeUsd24Hr"": 500000000, ""priceUsd"": 8.5, ""changePercent24Hr"": 1.2, ""vwap24Hr"": 8.4, ""explorer"": ""https://polkascan.io"" },
                { ""id"": ""tron"", ""rank"": 10, ""symbol"": ""TRX"", ""name"": ""TRON"", ""supply"": 90000000000, ""maxSupply"": null, ""marketCapUsd"": 8000000000, ""volumeUsd24Hr"": 300000000, ""priceUsd"": 0.09, ""changePercent24Hr"": -0.3, ""vwap24Hr"": 0.089, ""explorer"": ""https://tronscan.org"" }
            ]
        }";

            var assetsData = JsonConvert.DeserializeObject<AssetsData>(json);
            return await Task.FromResult(assetsData.Data);
        }

        public async Task<Asset> GetAssetByIDAsync(string id)
        {
            string json = @"
        {
            ""data"": {
                ""id"": ""bitcoin"",
                ""rank"": 1,
                ""symbol"": ""BTC"",
                ""name"": ""Bitcoin"",
                ""supply"": 19000000,
                ""maxSupply"": 21000000,
                ""marketCapUsd"": 800000000000,
                ""volumeUsd24Hr"": 30000000000,
                ""priceUsd"": 42000,
                ""changePercent24Hr"": 2.5,
                ""vwap24Hr"": 41500,
                ""explorer"": ""https://blockchain.com/explorer""
            }
        }";

            var assetData = JsonConvert.DeserializeObject<AssetData>(json);
            return await Task.FromResult(assetData.Data);
        }

        public async Task<List<AssetHistoryEntry>> GetAssetHistoryAsync(string id)
        {
            string json = @"
        {
            ""data"": [
                { ""priceUsd"": 40000, ""time"": 1715126400000 },
                { ""priceUsd"": 41000, ""time"": 1715212800000 },
                { ""priceUsd"": 42000, ""time"": 1715299200000 }
            ],
            ""timestamp"": 1715299200000
        }";

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new UnixMillisecondsDateTimeConverter() }
            };
            var history = JsonConvert.DeserializeObject<Asset.AssetHistory>(json, settings);
            return await Task.FromResult(history.Data);
        }

        public async Task<List<Market>> GetMarketsAsync()
        {
            string json = @"
        {
            ""data"": [
                { ""exchangeId"": ""binance"", ""rank"": ""1"", ""baseSymbol"": ""BTC"", ""baseId"": ""bitcoin"", ""quoteSymbol"": ""USDT"", ""quoteId"": ""tether"", ""priceQuote"": 42000, ""priceUsd"": 42000, ""volumeUsd24Hr"": 1500000000, ""percentExchangeVolume"": 35.5, ""tradesCount24Hr"": 120000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""coinbase"", ""rank"": ""2"", ""baseSymbol"": ""ETH"", ""baseId"": ""ethereum"", ""quoteSymbol"": ""USD"", ""quoteId"": ""usd"", ""priceQuote"": 3000, ""priceUsd"": 3000, ""volumeUsd24Hr"": 900000000, ""percentExchangeVolume"": 22.3, ""tradesCount24Hr"": 90000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""kraken"", ""rank"": ""3"", ""baseSymbol"": ""SOL"", ""baseId"": ""solana"", ""quoteSymbol"": ""USD"", ""quoteId"": ""usd"", ""priceQuote"": 125, ""priceUsd"": 125, ""volumeUsd24Hr"": 500000000, ""percentExchangeVolume"": 15.0, ""tradesCount24Hr"": 60000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""bybit"", ""rank"": ""4"", ""baseSymbol"": ""ADA"", ""baseId"": ""cardano"", ""quoteSymbol"": ""USDT"", ""quoteId"": ""tether"", ""priceQuote"": 0.43, ""priceUsd"": 0.43, ""volumeUsd24Hr"": 400000000, ""percentExchangeVolume"": 10.1, ""tradesCount24Hr"": 30000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""huobi"", ""rank"": ""5"", ""baseSymbol"": ""DOGE"", ""baseId"": ""dogecoin"", ""quoteSymbol"": ""USDT"", ""quoteId"": ""tether"", ""priceQuote"": 0.14, ""priceUsd"": 0.14, ""volumeUsd24Hr"": 300000000, ""percentExchangeVolume"": 7.5, ""tradesCount24Hr"": 25000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""okx"", ""rank"": ""6"", ""baseSymbol"": ""XRP"", ""baseId"": ""ripple"", ""quoteSymbol"": ""USDT"", ""quoteId"": ""tether"", ""priceQuote"": 0.6, ""priceUsd"": 0.6, ""volumeUsd24Hr"": 270000000, ""percentExchangeVolume"": 6.8, ""tradesCount24Hr"": 22000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""bitfinex"", ""rank"": ""7"", ""baseSymbol"": ""DOT"", ""baseId"": ""polkadot"", ""quoteSymbol"": ""USD"", ""quoteId"": ""usd"", ""priceQuote"": 8.5, ""priceUsd"": 8.5, ""volumeUsd24Hr"": 250000000, ""percentExchangeVolume"": 5.2, ""tradesCount24Hr"": 18000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""kucoin"", ""rank"": ""8"", ""baseSymbol"": ""TRX"", ""baseId"": ""tron"", ""quoteSymbol"": ""USDT"", ""quoteId"": ""tether"", ""priceQuote"": 0.09, ""priceUsd"": 0.09, ""volumeUsd24Hr"": 200000000, ""percentExchangeVolume"": 3.5, ""tradesCount24Hr"": 14000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""bitstamp"", ""rank"": ""9"", ""baseSymbol"": ""LTC"", ""baseId"": ""litecoin"", ""quoteSymbol"": ""USD"", ""quoteId"": ""usd"", ""priceQuote"": 85, ""priceUsd"": 85, ""volumeUsd24Hr"": 180000000, ""percentExchangeVolume"": 2.8, ""tradesCount24Hr"": 12000, ""updated"": 1715299200000 },
                { ""exchangeId"": ""gemini"", ""rank"": ""10"", ""baseSymbol"": ""AVAX"", ""baseId"": ""avalanche"", ""quoteSymbol"": ""USD"", ""quoteId"": ""usd"", ""priceQuote"": 35, ""priceUsd"": 35, ""volumeUsd24Hr"": 150000000, ""percentExchangeVolume"": 2.0, ""tradesCount24Hr"": 10000, ""updated"": 1715299200000 }
            ]
        }";

            var marketsData = JsonConvert.DeserializeObject<MarketsData>(json);
            return await Task.FromResult(marketsData.Data);
        }
    }
}
