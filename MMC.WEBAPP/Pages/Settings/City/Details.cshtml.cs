using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEBAPP.Services;
using M = MMC.Core.Models;

namespace MMC.WEBAPP.Pages.Settings.City;

public class DetailsModel : PageModel
{
    private readonly CityService _service;
    public DetailsModel(CityService service) => _service = service;




    [BindProperty]
    public M.City City { get; set; }




    public async Task OnGet(int id)
        => City = await _service.Find(id);


    public async Task<IActionResult> OnPostUpdate()
    {
        if (string.IsNullOrEmpty(City.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("City.Name", "The field \"Name\" is required!");
            return Page();
        }

        await _service.Update(City.Id, City);
        return RedirectToPage("/Settings/City/Index");
    }


    public async Task<IActionResult> OnPostDelete()
    {
        await _service.Delete(City.Id);
        return RedirectToPage("/Settings/City/Index");
    }
}
