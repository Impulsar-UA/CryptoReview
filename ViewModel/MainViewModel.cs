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
         GetTopAssets();
        }
        private MyHttpClient _myHttpClient = new MyHttpClient();
        public List<Asset> AssetsList { get; set; }
        public ObservableCollection<Asset> TopAssets { get; set; }
        public async Task GetAssetsList() 
        {
            AssetsList = await _myHttpClient.GetAllAssetsAsync();
        }
        public async void GetTopAssets()
        {
            await GetAssetsList();
            if (TopAssets != null) { TopAssets.Clear(); }
            for (int i = 0; i < 10; i++)
            TopAssets.Add(AssetsList[i]);
        }

        private void UpdateTop10()
        {
            GetTopAssets();
        }
        private RelayCommand? _updateTop10Command;
        public RelayCommand UpdateTop10Command
        {
            get
            {
                return _updateTop10Command ?? (_updateTop10Command = new RelayCommand(obj => UpdateTop10()));
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
