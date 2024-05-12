using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using static CryptoReview.Model.Asset;

namespace CryptoReview.Model
{
    public class MyHttpClient
    {
        private readonly HttpClient _client;

        public MyHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://api.coincap.io/v2/assets");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var assetsData = JsonConvert.DeserializeObject<AssetsData>(responseData);
                    return assetsData?.Data;
                }
                else
                {
                    MessageBox.Show("Http request error: " + response.StatusCode, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public async Task<Asset> GetAssetByIDAsync(string Id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"https://api.coincap.io/v2/assets/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var assetData = JsonConvert.DeserializeObject<AssetData>(responseData);
                    return assetData?.Data;
                }
                else
                {
                    MessageBox.Show("Http request error: " + response.StatusCode,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public async Task<List<AssetHistoryEntry>> GetAssetHistoryAsync(string Id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"https://api.coincap.io/v2/assets/{Id}/history?interval=d1");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new UnixMillisecondsDateTimeConverter() }
                    };
                    var responseObject = JsonConvert.DeserializeObject<AssetHistory>(jsonString, settings);
                    return responseObject.Data;
                }
                else
                {
                    MessageBox.Show("Http request error: " + response.StatusCode,"Error",  MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message , "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public async Task<List<Market>> GetMarketsAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://api.coincap.io/v2/markets");

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var marketsData = JsonConvert.DeserializeObject<MarketsData>(responseData);
                    return marketsData?.Data;
                }
                else
                {
                    MessageBox.Show("Http request error: " + response.StatusCode, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }      
    }
}
