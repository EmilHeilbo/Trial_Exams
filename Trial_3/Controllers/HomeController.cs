using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trial_3.Data;
using Trial_3.Models;

namespace Trial_3.Controllers;

public class HomeController : Controller
{
    private AppDbContext _context;

    public HomeController(AppDbContext context) => _context = context;

    public IActionResult Index() => View(_context.Products);

    public IActionResult Update(int id, int age)
    {
        ViewData["PriceTotal"] = _context.Products.Find(id)?.CalculateFinalPrice(age);
        return View(_context.Products);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
