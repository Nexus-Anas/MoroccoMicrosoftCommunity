using MMC.Core.Models;

namespace MMC.WEB.Services;

public class SpeakerInfoService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "SpeakerInfo";

    public SpeakerInfoService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<SpeakerInfo> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<SpeakerInfo>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<SpeakerInfo>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<SpeakerInfo>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<SpeakerInfo> Create(SpeakerInfo speaker)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", speaker);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SpeakerInfo>();
    }

    public async Task<SpeakerInfo> Update(int id, SpeakerInfo speaker)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", speaker);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<SpeakerInfo>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
