using CryptoReview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel () 
        {
          GetAssetsList(TopAssets);
        }
        private MyHttpClient _myHttpClient = new MyHttpClient();
        public List<Asset> TopAssets = new List<Asset>();
        public async void GetAssetsList(List<Asset> list) 
        {
            list = await _myHttpClient.GetAllAssetsAsync();
        }
    }
}
