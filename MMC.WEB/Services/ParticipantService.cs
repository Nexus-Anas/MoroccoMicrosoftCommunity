using MMC.Core.Models;

namespace MMC.WEB.Services;

public class ParticipantService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Participant";

    public ParticipantService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Participant> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<Participant>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<Participant>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Participant>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<Participant> Create(Participant participant)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", participant);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Participant>();
    }

    public async Task<Participant> Update(int id, Participant participant)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", participant);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Participant>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
