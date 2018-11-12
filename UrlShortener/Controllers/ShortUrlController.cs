using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Models.Commands;
using UrlShortener.Repositories;

namespace UrlShortener.Controllers
{
    [Route("api/shorturl")]
    public class ShortUrlController : Controller
    {
        private readonly IShortUrlRepository urlRepository;

        public ShortUrlController(IShortUrlRepository urlRepository)
        {
            this.urlRepository = urlRepository;
        }

        /// <summary>
        /// Method returns short url object associated with provided key.
        /// </summary>
        /// <param name="shortKey">Key of the short url record</param>
        /// <returns>Short Url object.</returns>
        [HttpGet("{shortKey}")]
        public async Task<ShortUrl> Get(string shortKey)
        {
            return await urlRepository.GetByKeyAsync(shortKey);
        }

        /// <summary>
        /// Create short url for the provided long url.
        /// TODO: Implement real shot url algorithm. 
        /// </summary>
        /// <param name="urlRequest">Url to be shortened.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]AddShortUrl urlRequest)
        {
            if (ModelState.IsValid)
            {
                var shortUrl = new ShortUrl
                {
                    FullUrl = urlRequest.Url.Trim(),
                    ShortKey = Convert
                            .ToBase64String(Guid.NewGuid().ToByteArray())
                            .Replace("+", "")
                            .Replace("/", "")
                            .Replace("==", "")
                };
                await urlRepository.AddAsync(shortUrl);
                return Ok(shortUrl);
            }

            return BadRequest(ModelState);
        }
    }
}
