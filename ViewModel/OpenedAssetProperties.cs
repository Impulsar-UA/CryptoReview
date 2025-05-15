using CryptoReview.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static CryptoReview.Model.Asset;

namespace CryptoReview.ViewModel
{
    public class AssetViewModel : INotifyPropertyChanged
    {
        private MyHttpClient _myHttpClient = new MyHttpClient();
        public AssetViewModel(string assetName)
        {
            AssetHistory = new ObservableCollection<AssetHistoryEntry>();
        }
        public ObservableCollection<AssetHistoryEntry> AssetHistory { get; set; }
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
        private string _searchingDate;
        public string? SearchingDate
        {
            get { return _searchingDate; }
            set
            {
                if (_searchingDate != value)
                {
                    _searchingDate = value;
                    OnPropertyChanged(nameof(SearchingDate));
                }
            }
        }

        private string _foundedPrice;
        public string FoundedPrice
        {
            get { return _foundedPrice; }
            set
            {
                if (_foundedPrice != value)
                {
                    _foundedPrice = value;
                    OnPropertyChanged(nameof(FoundedPrice));
                }
            }
        }
        public async Task UpdateAsset(string assetName)
        {

                Asset asset = await VMController.MainVM._myHttpClient.GetAssetByIDAsync(assetName);
                AssetId = asset.Id;
                await LoadAssetHistory();
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
        public async Task UpdateAsset()
        {
            Asset asset = await _myHttpClient.GetAssetByIDAsync(AssetId);
            AssetId = asset.Id;
            await LoadAssetHistory();
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
        private RelayCommand? _updateAssetCommand;
        public RelayCommand UpdateAssetCommand
        {
            get
            {
                return _updateAssetCommand ?? (_updateAssetCommand = new RelayCommand(obj => UpdateAsset()));
            }
        }

        private async Task LoadAssetHistory()
        {
            AssetHistory.Clear();
            var historyList = await VMController.MainVM._myHttpClient.GetAssetHistoryAsync(AssetId);
            foreach (var item in historyList)
            {
                AssetHistory.Add(item);
            }
        }
        public void SearchPrice()
        {
            if (string.IsNullOrWhiteSpace(SearchingDate))
            {
                FoundedPrice = "Please enter a valid date.";
                return;
            }

            if (!DateTimeOffset.TryParse(SearchingDate, out DateTimeOffset searchDateTime))
            {
                FoundedPrice = "Invalid date format.";
                return;
            }

            var entry = AssetHistory.FirstOrDefault(e => e.Time.Date == searchDateTime.Date);

            if (entry != null)
            {
                FoundedPrice = $"Price on {entry.Time.Date.ToString("yyyy-MM-dd")}: {entry.PriceUsd}";
            }
            else
            {
                FoundedPrice = $"Price not found for {searchDateTime.Date.ToString("yyyy-MM-dd")}";
            }
        }
        private RelayCommand? _searchPriceCommand;
        public RelayCommand SearchPriceCommand
        {
            get
            {
                return _searchPriceCommand ?? (_searchPriceCommand = new RelayCommand(obj => SearchPrice()));
            }
        }     
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}