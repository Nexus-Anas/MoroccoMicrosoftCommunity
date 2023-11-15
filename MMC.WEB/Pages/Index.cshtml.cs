using Microsoft.AspNetCore.Mvc.RazorPages;
using MMC.WEB.Services;
using M = MMC.Core.Models;

namespace MMC.WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventService _service;
        private readonly CategoryService _Cservice;



        public IndexModel(ILogger<IndexModel> logger, EventService service, CategoryService cservice)
        {
            _logger = logger;
            _service = service;
            _Cservice = cservice;
        }


        public int EventCount { get; set; }
        public int CategoryCount { get; set; }

        public IEnumerable<M.Event> Events { get; set; }
        public IEnumerable<M.Category> Categories { get; set; }




        public async Task OnGet()
        {
            Events = await _service.FindAll();
            EventCount = Events.Count();
            Categories = await _Cservice.FindAll();
            CategoryCount = Categories.Count();
        }

    }
}