using RestSharp;

namespace Pim_Web.Services
{
    public class WeatherApi
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public WeatherApi(string apiKey)
        {
            _apiKey = apiKey;
            _baseUrl = "http://api.openweathermap.org/data/2.5/";
        }

        public async Task<string> GetWeatherData(string city)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?q={city}&appid={_apiKey}", Method.Get);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
