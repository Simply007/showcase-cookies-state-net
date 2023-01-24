using System.Diagnostics;
using Kontent.Ai.Delivery.Abstractions;
using Microsoft.AspNetCore.Mvc;
using showcase_cookies_state_net.Models;

namespace showcase_cookies_state_net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDeliveryClient _previewDeliveryClient;
    private readonly IDeliveryClient _productionDeliveryClient;


    public HomeController(ILogger<HomeController> logger, IDeliveryClientFactory deliveryClientFactory)
    {
        _logger = logger;
        _previewDeliveryClient = deliveryClientFactory.Get("preview");
        _productionDeliveryClient = deliveryClientFactory.Get("production");
    }

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
}
