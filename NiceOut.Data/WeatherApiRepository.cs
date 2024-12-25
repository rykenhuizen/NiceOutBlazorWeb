using System.Net.Http.Json;
using NiceOut.Models;
using static NiceOut.Models.WeatherApi;


namespace NiceOut.Data
{
    public class WeatherApiRepository
    {
        public async Task<WeatherApiModel> GetApiData()
        {
            var client = new HttpClient();
            var sUrl = "http://api.weatherapi.com/v1/forecast.json?key=683327de749c47aab80153219242312&q=Halifax&days=1&aqi=no&alerts=no";
            var result = await client.GetFromJsonAsync<WeatherApiModel>(sUrl);
            return result;
            //var response = await client.GetFromJsonAsync<WeatherApi>(sUrl);
            //return response ?? throw new InvalidOperationException("Failed to fetch weather data.");
        }
    }
}
