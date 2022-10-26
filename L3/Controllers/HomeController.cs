using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using L3.Models;

namespace L3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PhoneBookService _phoneBook;

    public HomeController(ILogger<HomeController> logger, PhoneBookService phoneBook)
    {
        _logger = logger;
        _phoneBook = phoneBook;
    }

    public IActionResult Index()
    {
        return View(_phoneBook.GetContacts());
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _phoneBook.Add(contact);
            return RedirectToAction("Index");
        }

        return View();
    }
    
    public IActionResult Delete(int id)
    {
        if (_phoneBook.Remove(id))
        {
            return RedirectToAction("Index");
        }
        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}