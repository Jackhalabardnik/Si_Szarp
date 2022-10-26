using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace L4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty] public IFormFile Upload { get; set; } = null!;
        private string _imagesDir;

        public UploadModel(IWebHostEnvironment environment)
        {
            _imagesDir = Path.Combine(environment.WebRootPath, "images");
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Upload is not null)
            {
                string extension = Upload.ContentType switch
                {
                    "image/png" => ".png",
                    "image/gif" => ".gif",
                    _ => ".jpg"
                };

                var fileName = string.Format("{0}{1}", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()),
                    extension);

                using (var fs = System.IO.File.OpenWrite(Path.Combine(_imagesDir, fileName)))
                {
                    Upload.CopyTo(fs);
                }
            }

            return RedirectToPage("Index");
        }
    }
}