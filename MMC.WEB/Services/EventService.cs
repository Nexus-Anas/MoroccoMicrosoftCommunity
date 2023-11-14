using MMC.Core.Models;

namespace MMC.WEB.Services;

public class EventService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Event";

    public EventService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Event> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<Event>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<Event>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Event>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<Event> Create(Event @event)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", @event);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Event>();
    }

    public async Task<Event> Update(int id, Event @event)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller} /{id}", @event);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Event>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}