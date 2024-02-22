using CryptoReview.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.ViewModel
{
    public class MainViewModel
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
    }
}
