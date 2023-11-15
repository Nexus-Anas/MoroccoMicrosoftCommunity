using MMC.Core.Models;

namespace MMC.WEBAPP.Services;

public class UserService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "City";

    public UserService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<User> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<User>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<User>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<User>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<User> Create(User user)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }

    public async Task<User> Update(int id, User user)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
