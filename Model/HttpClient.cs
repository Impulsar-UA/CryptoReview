using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

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
                    MessageBox.Show("Error", "Http request error: " + response.StatusCode, MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show("Error", "Http request error: " + response.StatusCode, MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public async Task<string> GetAssetHistoryAsync(string Id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"https://api.coincap.io/v2/assets/{Id}/history");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("Error", "Http request error: " + response.StatusCode, MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public async Task<string> GetAssetMarketsAsync(string Id)
        {
            return await SendGetRequest($"https://api.coincap.io/v2/assets/{Id}/markets");
        }

        private async Task<string?> SendGetRequest(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("Error", "Http request error: " + response.StatusCode, MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error: " + ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
