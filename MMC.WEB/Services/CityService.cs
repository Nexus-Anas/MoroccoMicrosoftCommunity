using MMC.Core.Models;

namespace MMC.WEB.Services;

public class CityService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public CityService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<City> GetCity(int id)
    {
        var response = await _http.GetFromJsonAsync<City>($"{_baseUrl}api/City/{id}");
        return response;
    }

    public async Task<IEnumerable<City>> GetAllCities()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<City>>($"{_baseUrl}api/City");
        return response;
    }

    public async Task<City> CreateCity(City city)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/City", city);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<City>();
    }

    public async Task<City> UpdateCity(int id, City city)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/City/{id}", city);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<City>();
    }

    public async Task DeleteCity(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/City/{id}");
        response.EnsureSuccessStatusCode();
    }
}