using MMC.Core.Models;

namespace MMC.WEBAPP.Services;

public class CityService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "City";

    public CityService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<City> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<City>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<City>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<City>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<City> Create(City city)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", city);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<City>();
    }

    public async Task<City> Update(int id, City city)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", city);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<City>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}