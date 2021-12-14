using csApiApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using csApiApp.Services.Rest.Endpoints;
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

        public async Task<List<DealResult>> GetDealsAsync()
        {
            List<DealResult> deals;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.DealOfTheDayEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    deals = JsonConvert.DeserializeObject<List<DealResult>>(content);
                }
                else
                {
                    Debug.Write("\tERROR - HTTP Status Code: {0}", response.StatusCode.ToString());
                    deals = new List<DealResult>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return deals;
        }

        //public async Task<GameResult> GetDealOfTheDayAsync(string uri)
        //{
        //    GameResult dealOfTheDay = null;
        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            //content = content.Replace(@"\", string.Empty);
        //            dealOfTheDay = JsonConvert.DeserializeObject<GameResult>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }

        //    return dealOfTheDay;
        //}
    }
}