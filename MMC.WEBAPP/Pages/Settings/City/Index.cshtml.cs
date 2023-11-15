using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEBAPP.Services;
using M = MMC.Core.Models;

namespace MMC.WEBAPP.Pages.City;

public class IndexModel : PageModel
{
    private readonly CityService _service;
    public IndexModel(CityService service) => _service = service;




    [BindProperty]
    public M.City City { get; set; }
    public IEnumerable<M.City> Cities { get; private set; }




    public async Task OnGet()
        => Cities = await _service.FindAll();


    public async Task<IActionResult> OnPostCreate()
    {
        if (string.IsNullOrEmpty(City.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("City.Name", "The field \"Name\" is required!");
            await OnGet();
            return Page();
        }

        await _service.Create(City);
        return RedirectToPage("/Settings/City/Index");
    }
}