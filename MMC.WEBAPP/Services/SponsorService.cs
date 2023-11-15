using MMC.Core.Models;

namespace MMC.WEBAPP.Services;

public class SponsorService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Sponsor";

    public SponsorService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Sponsor> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<Sponsor>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<Sponsor>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Sponsor>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<Sponsor> Create(Sponsor sponsor)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", sponsor);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Sponsor>();
    }

    public async Task<Sponsor> Update(int id, Sponsor sponsor)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", sponsor);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Sponsor>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
