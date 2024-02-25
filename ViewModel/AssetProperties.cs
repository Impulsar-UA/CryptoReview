using CryptoReview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.ViewModel
{
    public partial class MainViewModel
    {
        private string _assetId;
        public string AssetId
        {
            get { return _assetId; }
            set
            {
                    _assetId = value;
                    OnPropertyChanged(nameof(AssetId));
            }
        }
        private int _assetRank;
        public int AssetRank
        {
            get { return _assetRank; }
            set
            {
                    _assetRank = value;
                    OnPropertyChanged(nameof(AssetRank));
            }
        }
        private string _assetSymbol;
        public string AssetSymbol
        {
            get { return _assetSymbol; }
            set
            {
                if (_assetSymbol != value)
                {
                    _assetSymbol = value;
                    OnPropertyChanged(nameof(AssetSymbol));
                }
            }
        }
        private string _assetName;
        public string AssetName
        {
            get { return _assetName; }
            set
            {
                    _assetName = value;
                    OnPropertyChanged(nameof(AssetName));
            }
        }
        private double _assetSupply;
        public double AssetSupply
        {
            get { return _assetSupply; }
            set
            {
                if (_assetSupply != value)
                {
                    _assetSupply = value;
                    OnPropertyChanged(nameof(AssetSupply));
                }
            }
        }
        private double? _assetMaxSupply;
        public double? AssetMaxSupply
        {
            get { return _assetMaxSupply; }
            set
            {
                if (_assetMaxSupply != value)
                {
                    _assetMaxSupply = value;
                    OnPropertyChanged(nameof(AssetMaxSupply));
                }
            }
        }
        private double? _assetMarketCapUsd;
        public double? AssetMarketCapUsd
        {
            get { return _assetMarketCapUsd; }
            set
            {
                if (_assetMarketCapUsd != value)
                {
                    _assetMarketCapUsd = value;
                    OnPropertyChanged(nameof(AssetMarketCapUsd));
                }
            }
        }
        private double? _assetVolumeUsd24Hr;
        public double? AssetVolumeUsd24Hr
        {
            get { return _assetVolumeUsd24Hr; }
            set
            {
                if (_assetVolumeUsd24Hr != value)
                {
                    _assetVolumeUsd24Hr = value;
                    OnPropertyChanged(nameof(AssetVolumeUsd24Hr));
                }
            }
        }
        private double _assetPriceUsd;
        public double AssetPriceUsd
        {
            get { return _assetPriceUsd; }
            set
            {
                if (_assetPriceUsd != value)
                {
                    _assetPriceUsd = value;
                    OnPropertyChanged(nameof(AssetPriceUsd));
                }
            }
        }
        private double? _assetChangePercent24Hr;
        public double? AssetChangePercent24Hr
        {
            get { return _assetChangePercent24Hr; }
            set
            {
                if (_assetChangePercent24Hr != value)
                {
                    _assetChangePercent24Hr = value;
                    OnPropertyChanged(nameof(AssetChangePercent24Hr));
                }
            }
        }
        private double? _assetVwap24Hr;
        public double? AssetVwap24Hr
        {
            get { return _assetVwap24Hr; }
            set
            {
                if (_assetVwap24Hr != value)
                {
                    _assetVwap24Hr = value;
                    OnPropertyChanged(nameof(AssetVwap24Hr));
                }
            }
        }
        private string? _assetExplorer;
        public string? AssetExplorer
        {
            get { return _assetExplorer; }
            set
            {
                if (_assetExplorer != value)
                {
                    _assetExplorer = value;
                    OnPropertyChanged(nameof(AssetExplorer));
                }
            }
        }

        public async Task GetAsset(string name)
        {
            Asset asset = await _myHttpClient.GetAssetByIDAsync(name);
            AssetId = asset.Id;
            AssetRank = asset.Rank;
            AssetSymbol = asset.Symbol;
            AssetName = asset.Name;
            AssetSupply = asset.Supply;
            AssetMaxSupply = asset.MaxSupply;
            AssetMarketCapUsd = asset.MarketCapUsd;
            AssetVolumeUsd24Hr = asset.VolumeUsd24Hr;
            AssetPriceUsd = asset.PriceUsd;
            AssetChangePercent24Hr = asset.ChangePercent24Hr;
            AssetVwap24Hr = asset.Vwap24Hr;
            AssetExplorer = asset.Explorer;
        }
    }
}
