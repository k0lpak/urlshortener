using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Repositories
{
    public interface IShortUrlRepository
    {
        Task<ShortUrl> GetByKeyAsync(string shortKey);

        Task AddAsync(ShortUrl url);
    }
}
