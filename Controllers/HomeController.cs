using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataProtectionDemo.Models;
using DataProtectionDemo.ViewModels;

namespace DataProtectionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(string? message)
    {
        return View(new HomeViewModel { Message = message });
    }

    [HttpPost]
    public IActionResult SubmitMessage([FromForm] string? message)
    {
        return RedirectToAction(nameof(Index), new { message });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
