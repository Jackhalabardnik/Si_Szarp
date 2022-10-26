using Microsoft.AspNetCore.Mvc.RazorPages;

namespace L4.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private string _imagesDir;
    public List<string> Images { get; set; } = null!;

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _imagesDir = Path.Combine(environment.WebRootPath, "images");
    }
    
    private void UpdateFileList()
    {
        Images = new List<string>();
        foreach (var item in Directory.EnumerateFiles(_imagesDir).ToList())
        {
            Images.Add(Path.GetFileName(item));
        }
    }
    
    public void OnGet()
    {
        UpdateFileList();
    }
}