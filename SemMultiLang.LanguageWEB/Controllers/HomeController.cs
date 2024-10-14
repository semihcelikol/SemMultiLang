using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SemMultiLang.LanguageLib.Languages;
using SemMultiLang.LanguageWEB.Models;
using System.Diagnostics;

namespace SemMultiLang.LanguageWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<Lang> stringLocalizer)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeLabel = _stringLocalizer["Welcome"];

            LanguageLib.LanguageHelper languageHelper = new LanguageLib.LanguageHelper();

            // + LanguageHelper
            string activeCulture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;

            ViewBag.HomeLabel = languageHelper.GetLabel(activeCulture, "Home");
            //-

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
