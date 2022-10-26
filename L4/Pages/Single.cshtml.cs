using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ML;

namespace L4.Pages
{
    public class SingleModel : PageModel
    {
        [BindProperty(SupportsGet = true)] public string Image { get; set; }
        public string Label { get; set; }
        public float Probability { get; set; }

        private string _imagesDir;
        private readonly Inception5h _pred;

        public SingleModel(IWebHostEnvironment environment, ML.Inception5h pred)
        {
            _imagesDir = Path.Combine(environment.WebRootPath, "images");
            _pred = pred;
        }

        public IActionResult OnGet()
        {
            if (System.IO.File.Exists(Path.Combine(_imagesDir, Image)))
            {
                (Label, Probability) = _pred.Label(Path.Combine(_imagesDir, Image));
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}