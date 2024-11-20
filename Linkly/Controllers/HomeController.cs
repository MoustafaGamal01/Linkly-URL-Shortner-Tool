using Linkly.Models;
using Linkly.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Linkly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IUrlService _urlService;

		public HomeController(ILogger<HomeController> logger, IUrlService urlService)
        {
            _logger = logger;
			_urlService = urlService;
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

		[HttpGet("{shortUrl}")]
		public async Task<IActionResult> RedirectToOriginal(string shortUrl)
		{
			var orgUrl = await _urlService.GetOriginal(shortUrl);
			if (string.IsNullOrEmpty(orgUrl))
			{
				return NotFound("The shortened URL does not exist.");
			}

			return Redirect(orgUrl);
		}
	}
}
