using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEB.Services;
using M = MMC.Core.Models;

namespace MMC.WEB.Pages.Settings.Category;

public class DetailsModel : PageModel
{
    private readonly CategoryService _service;
    public DetailsModel(CategoryService service) => _service = service;




    [BindProperty]
    public M.Category Category { get; set; }




    public async Task OnGet(int id)
        => Category = await _service.Find(id);


    public async Task<IActionResult> OnPostUpdate()
    {
        if (string.IsNullOrEmpty(Category.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("Category.Name", "The field \"Name\" is required!");
            return Page();
        }

        await _service.Update(Category.Id, Category);
        return RedirectToPage("/Settings/Category/Index");
    }


    public async Task<IActionResult> OnPostDelete()
    {
        await _service.Delete(Category.Id);
        return RedirectToPage("/Settings/Category/Index");
    }
}
