using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEB.Services;
using M = MMC.Core.Models;

namespace MMC.WEB.Pages.City;

public class IndexModel : PageModel
{
    private readonly CityService _service;
    public IndexModel(CityService service) => _service = service;


    public IEnumerable<M.City> Cities { get; private set; }

    public async Task OnGet()
        => Cities = await _service.GetAllCities();
}
