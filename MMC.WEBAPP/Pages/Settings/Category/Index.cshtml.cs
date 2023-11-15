using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEBAPP.Services;
using M = MMC.Core.Models;

namespace MMC.WEBAPP.Pages.Settings.Category;

public class IndexModel : PageModel
{
    private readonly CategoryService _service;
    public IndexModel(CategoryService service) => _service = service;




    [BindProperty]
    public M.Category Category { get; set; }
    public IEnumerable<M.Category> Categories { get; private set; }




    public async Task OnGet()
        => Categories = await _service.FindAll();


    public async Task<IActionResult> OnPostCreate()
    {
        if (string.IsNullOrEmpty(Category.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("Category.Name", "The field \"Name\" is required!");
            await OnGet();
            return Page();
        }

        await _service.Create(Category);
        return RedirectToPage("/Settings/Category/Index");
    }
}