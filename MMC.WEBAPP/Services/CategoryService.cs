using MMC.Core.Models;

namespace MMC.WEBAPP.Services;

public class CategoryService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private string _controller = "Category";

    public CategoryService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    }

    public async Task<Category> Find(int id)
    {
        var response = await _http.GetFromJsonAsync<Category>($"{_baseUrl}api/{_controller}/{id}");
        return response;
    }

    public async Task<IEnumerable<Category>> FindAll()
    {
        var response = await _http.GetFromJsonAsync<IEnumerable<Category>>($"{_baseUrl}api/{_controller}");
        return response;
    }

    public async Task<Category> Create(Category category)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}api/{_controller}", category);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Category>();
    }

    public async Task<Category> Update(int id, Category category)
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}api/{_controller}/{id}", category);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Category>();
    }

    public async Task Delete(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}api/{_controller}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
