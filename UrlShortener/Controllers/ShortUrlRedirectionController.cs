using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Repositories;

namespace UrlShortener.Controllers
{
    [Route("")]
    public class ShortUrlRedirectionController : Controller
    {
        private readonly IShortUrlRepository urlRepository;

        public ShortUrlRedirectionController(IShortUrlRepository urlRepository)
        {
            this.urlRepository = urlRepository;
        }

        [HttpGet("{shortKey}")]
        public async Task<ActionResult> Get(string shortKey)
        {
            var shortUrl = await urlRepository.GetByKeyAsync(shortKey);
            if (shortUrl == null)
            {
                return NotFound();
            }
            
            return Redirect(shortUrl.FullUrl);
        }
    }
}
