using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using vaibhavmvc.Models;
using BOL;
using DAL;

namespace vaibhavmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Student> stu=StudentAccessData.GetAllStudent();
        ViewBag.student=stu;
        return View();
    }
 public IActionResult Student()
    {
        return View();
    }
    public IActionResult Submit()
    {
        return View();
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
