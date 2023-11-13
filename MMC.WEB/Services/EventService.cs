using MMC.Core.Models;

namespace MMC.WEB.Services;

public class EventService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public EventService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Event> GetEvent(int id)
    {
        var response = await _http.GetFromJsonAsync<Event>($"{_baseUrl}api/Event/{id}");
        return response;
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Event>>($"{_baseUrl}api/Event");
        return response;
    }

    public async Task<Event> CreateEvent(Event @event)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/Event", @event);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Event>();
    }

    public async Task<Event> UpdateEvent(int id, Event @event)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/Event/{id}", @event);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Event>();
    }

    public async Task DeleteEvent(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/Event/{id}");
        response.EnsureSuccessStatusCode();
    }
}