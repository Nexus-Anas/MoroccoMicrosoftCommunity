using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEBAPP.Services;
using M = MMC.Core.Models;

namespace MMC.WEBAPP.Pages.Event;

public class IndexModel : PageModel
{
    private readonly EventService _service;
    public IndexModel(EventService service) => _service = service;




    public IEnumerable<M.Event> Events { get; set; }
    public IEnumerable<M.City> Cities { get; private set; }
    public IEnumerable<M.Category> Categories { get; private set; }




    public async Task OnGet()
    {
        Events = await _service.FindAll();
        Cities = await _service.FindAllCities();
        Categories = await _service.FindAllCategories();
    }
}
