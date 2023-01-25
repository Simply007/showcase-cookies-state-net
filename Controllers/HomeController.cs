using System.Diagnostics;
using Kontent.Ai.Delivery.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShowcaseCookiesStateNet.Models;
using ShowcaseCookiesStateNet.Models.Generated;

namespace ShowcaseCookiesStateNet.Controllers;

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

    public async Task<IActionResult> Index()
    {
        var client = (Request.Cookies["preview"] ?? "false") == "false" ? _productionDeliveryClient : _previewDeliveryClient;
        var home = await client.GetItemAsync<object>("homepage");

        var result = JObject.Parse(home.ApiResponse.Content);


        var contentItemCodename = result["item"]?["elements"]?["content"]?["value"]?.First().ToString();
        var title = result?["modular_content"]?[contentItemCodename ?? ""]?["elements"]?["title"]?["value"]?.ToString();

        ViewBag.Title = title ?? "TITLE NOT FOUND - check implementation";

        return View();
    }

    public IActionResult Cookie()
    {
        var currentCookie = Request.Cookies["preview"] ?? "false";

        Response.Cookies.Append("preview", currentCookie == "false" ? "true" : "false");

        return Redirect("/");
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
