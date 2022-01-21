using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trial_3.Data;
using Trial_3.Models;

namespace Trial_3.Controllers;

public class HomeController : Controller
{
    private ProductsViewModel _model = new ProductsViewModel();

    public HomeController(AppDbContext context) => _model.Products = context.Products;

    public IActionResult Index() => View(_model);

    [HttpPost]
    public IActionResult Index(Guid pID, int age)
        {
            _model.Total = _model.Products.FirstOrDefault(p => p.Id.Equals(pID))?.CalculateFinalPrice(age) ?? 0m;
            return View(_model);
        }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
        { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
