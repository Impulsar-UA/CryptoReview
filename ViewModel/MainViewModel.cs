using CryptoReview.Model;
using CryptoReview.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoReview.ViewModel
{
    public static class VMController
    {
        public static MainViewModel MainVM = new();
    }
    public partial class MainViewModel
    {
        public MainViewModel () 
        {
         TopAssets = new ObservableCollection<Asset> ();
         AllAssets = new ObservableCollection<Asset> ();
         CryptoMarkets = new ObservableCollection<Market> ();
         GetTopAssets();
         GetAllAssets();
         GetAllMarkets();
        }
        private MyHttpClient _myHttpClient = new MyHttpClient();
        public List<Asset> AssetsList { get; set; }
        public List<Market> MarketsList { get; set; }
        public ObservableCollection<Asset> TopAssets { get; set; }
        public ObservableCollection<Asset> AllAssets { get; set; }
        public ObservableCollection<Market> CryptoMarkets { get; set; }
        public async Task GetAssetsList() 
        {
            AssetsList = await _myHttpClient.GetAllAssetsAsync();
        }
        public async Task GetMarketsList()
        {
            MarketsList = await _myHttpClient.GetMarketsAsync();               
        }
        public async void GetTopAssets()
        {
            await GetAssetsList();
            if (TopAssets != null) { TopAssets.Clear(); }
            for (int i = 0; i < 10; i++)
            TopAssets.Add(AssetsList[i]);
        }
        public async void GetAllMarkets()
        {
            await GetMarketsList();
            if (CryptoMarkets != null) { CryptoMarkets.Clear(); }
            for (int i = 0; i < 10; i++)
                CryptoMarkets.Add(MarketsList[i]);
        }
        public async void GetAllAssets()
        {
            await GetAssetsList();
            if (AllAssets != null) { AllAssets.Clear(); }
            for (int i = 0; i < AssetsList.Count; i++)
                AllAssets.Add(AssetsList[i]);
        }

        private RelayCommand? _updateTop10Command;
        public RelayCommand UpdateTop10Command
        {
            get
            {
                return _updateTop10Command ?? (_updateTop10Command = new RelayCommand(obj => GetTopAssets()));
            }
        }
        private RelayCommand? _updateAllAssetsCommand;
        public RelayCommand UpdateAllAssetsCommand
        {
            get
            {
                return _updateAllAssetsCommand ?? (_updateAllAssetsCommand = new RelayCommand(obj => GetAllAssets()));
            }
        }
        private RelayCommand? _updateMarketsCommand;
        public RelayCommand UpdateMarketsCommand
        {
            get
            {
                return _updateMarketsCommand ?? (_updateMarketsCommand = new RelayCommand(obj => GetAllMarkets()));
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
