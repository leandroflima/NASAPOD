using Microsoft.Extensions.Configuration;
using NASAPOD.Infra.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASAPOD.Infra.Services
{
    public class ApodService : IApodService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApodService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<PictureOfDayDto> GetPictureOfDay(GetPictureOfDayFilter getPictureOfDayFilter)
        {
            var date = getPictureOfDayFilter.Date.ToString("yyyy-MM-dd");
            var apiKey = _configuration.GetValue<string>("NasaApodApiKey");
            
            var baseAddress = _configuration.GetValue<string>("NasaApodBaseAddress");
            
            var requestUri = baseAddress + $"?api_key={apiKey}&date={date}";

            var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return new PictureOfDayDto($"Fail on request Uri:{requestUri}. return statuscode:{response.StatusCode}");
            }

            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var getPictureOfDayDto = JsonConvert.DeserializeObject<PictureOfDayDto>(responseString);

            return getPictureOfDayDto;
        }
    }
}
