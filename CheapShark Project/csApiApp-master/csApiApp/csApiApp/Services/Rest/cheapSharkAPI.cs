using csApiApp.Models;
using csApiApp.Mvvm.Model;
using csApiApp.Services.Rest.Endpoints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace csApiApp.Services.Rest
{
    public class CheapSharkAPI
    {
        private HttpClient _client;

        public CheapSharkAPI(HttpClient client)
        {
            _client = client;

            if (Device.RuntimePlatform == Device.UWP)
            {
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            }
        }

        public async Task<List<DealResult>> GetDealsAsync(string url)
        {
            List<DealResult> deals = new List<DealResult>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    deals = JsonConvert.DeserializeObject<List<DealResult>>(content);
                }
                else
                {
                    Debug.Write("\tERROR - HTTP Status Code: {0}", response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return deals;
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            List<Store> storeList = new List<Store>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.StoreListEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    storeList = JsonConvert.DeserializeObject<List<Store>>(content);
                }
                else
                {
                    Debug.Write("\tERROR - HTTP Status Code: {0}", response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return storeList;
        }

        internal async Task<List<SearchResult>> GetSearchAsync(string uri)
        {
            List<SearchResult> results = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<List<SearchResult>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return results;
        }
    }
}