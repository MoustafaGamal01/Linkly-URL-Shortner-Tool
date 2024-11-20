using Linkly.Models;
using Microsoft.EntityFrameworkCore;

namespace Linkly.Services
{
    public class UrlService : IUrlService
    {
        private readonly MyContext _myContext;

        public UrlService(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<bool?> Create(UrlModel url)
        {
            var isFound = await Find(url.LongUrl);

            if (isFound == true)
            {
                return false;
            }

            try
            {
                await _myContext.Urls.AddAsync(url);
                return await _myContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Find(string orgUrl)
        {
            try
            {
                return await _myContext.Urls.AnyAsync(x => x.LongUrl == orgUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UrlModel>> Get()
        {
            return await _myContext.Urls
                .ToListAsync();
        }

        public async Task<string> GetOriginal(string shortUrl)
        {
            try
            {
                return await _myContext.Urls
                    .Where(x => x.ShortUrl == shortUrl)
                    .Select(x => x.LongUrl)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
