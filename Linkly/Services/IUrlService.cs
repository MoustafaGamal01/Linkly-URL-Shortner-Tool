using Linkly.Models;

namespace Linkly.Services
{
    public interface IUrlService
    {
        Task<bool?> Create(UrlModel url);
        Task<List<UrlModel>> Get();
        Task<bool> Find(string orgUrl);
        Task<string> GetOriginal(string shortUrl);
    }
}
