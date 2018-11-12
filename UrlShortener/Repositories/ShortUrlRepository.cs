using Amazon.DynamoDBv2.DataModel;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly IDynamoDBContext db;

        public ShortUrlRepository(IDynamoDBContext db)
        {
            this.db = db;
        }

        public Task AddAsync(ShortUrl url)
        {
            return db.SaveAsync(url);
        }

        public Task<ShortUrl> GetByKeyAsync(string shortKey)
        {
            return db.LoadAsync<ShortUrl>(shortKey);
        }
    }
}
