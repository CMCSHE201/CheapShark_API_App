using SpaceDonkey.Models.Apod;
using SpaceDonkey.Services.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDonkey.Services
{
    public class ApodService
    {
        private readonly IRestService _restService;
        private readonly string _apiPath;
        private readonly string _apiKey;

        public ApodService(IRestService restService, string apiPath, string apiKey)
        {
            _restService = restService;
            _apiPath = apiPath;
            _apiKey = apiKey;
        }

        public async Task<(ResultStatus status, IEnumerable<ApodResponse>payload, string rawResponse)> GetApodAsync(DateTime pictureDate)
        {

            return await _restService.GetAsync<IEnumerable<ApodResponse>>(_apiPath + $"?start_date={pictureDate.ToString("yyyy-MM-dd")}&end_date={pictureDate.ToString("yyyy-MM-dd")}&api_key={_apiKey}");
        }
    }
}
