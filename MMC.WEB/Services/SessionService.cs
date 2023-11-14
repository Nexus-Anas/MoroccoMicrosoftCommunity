using MMC.Core.Models;

namespace MMC.WEB.Services;

public class SessionService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Session";

    public SessionService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Session> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<Session>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<Session>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Session>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<Session> Create(Session session)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", session);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Session>();
    }

    public async Task<Session> Update(int id, Session session)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", session);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Session>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
