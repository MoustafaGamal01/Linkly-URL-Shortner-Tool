using Linkly.Models;
using Linkly.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Linkly.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<IActionResult> Generate(string longUrl)
        {
            var hash = GetHash(longUrl);
            var shortUrlCode = Base62Encode(hash);

            var newUrl = new UrlModel
            {
                LongUrl = longUrl,
                ShortUrl = shortUrlCode
            };

            await _urlService.Create(newUrl);

            return View("Index", newUrl);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Hashing

        private string GetHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private string Base62Encode(string hash)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
           
            var result = new StringBuilder();
           
            foreach (var b in Encoding.ASCII.GetBytes(hash))
                result.Append(chars[b % 62]);
            
            // first 6 characters
            return result.ToString().Substring(0, 6);
        }

        #endregion
    }
}
