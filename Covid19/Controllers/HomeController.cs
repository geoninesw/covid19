using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Covid19.Models;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Covid19.EntityModel;

namespace Covid19.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer localizer, IOptions<RequestLocalizationOptions> LocOptions, IConfiguration config, Covid19Context context)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            //Response.Cookies.Append(
            //    CookieRequestCultureProvider.DefaultCookieName,
            //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")),
            //    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            //);

            ViewBag._Localizer = _localizer;

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
}
