using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Almostengr.LightShow.ConnectWeb.Models;
using Almostengr.Common.Common.Shared;

namespace Almostengr.LightShow.ConnectWeb.Controllers;

public class HomeController : UiController
{
    public IActionResult Index()
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

    public IActionResult RunMode()
    {
        return PartialView("_RunMode");
    }

    public IActionResult Documentation()
    {
        const string README = "README.md";
        if (!Path.Exists(README))
        {
            return NotFoundView();
        }

        return File(System.IO.File.ReadAllBytes(README), "plain/txt", README);
    }
}
