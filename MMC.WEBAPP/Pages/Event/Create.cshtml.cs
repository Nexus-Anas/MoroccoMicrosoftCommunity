using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEBAPP.Services;
using M = MMC.Core.Models;

namespace MMC.WEBAPP.Pages.Event;

public class CreateModel : PageModel
{
    private readonly EventService _service;
    private readonly IWebHostEnvironment _env;
    public CreateModel(EventService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }




    [BindProperty]
    public M.Event Event { get; set; }
    public IEnumerable<M.City> Cities { get; private set; }
    public IEnumerable<M.Category> Categories { get; private set; }




    public async Task OnGet()
    {
        Cities = await _service.FindAllCities();
        Categories = await _service.FindAllCategories();
    }




    public async Task<IActionResult> OnPostCreate()
    {
        Event.ImagePath = await InsertImagesAsync();
        if (string.IsNullOrEmpty(Event.Name) || !ModelState.IsValid)
        {
            ModelState.AddModelError("Event.Name", "The field \"Name\" is required!");
            await OnGet();
            return Page();
        }

        await _service.Create(Event);
        return RedirectToPage("/Event/Index");
    }





    private async Task<string> InsertImagesAsync()
    {
        string path = string.Empty;
        try
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
                        var filePath = Path.Combine(_env.WebRootPath, "images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                            await file.CopyToAsync(stream);
                        path = fileName;
                    }
                }
            }
            return path;
        }
        catch (Exception)
        {
            return null;
        }
    }
}