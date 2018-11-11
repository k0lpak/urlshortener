using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Route("api/shorturl")]
    public class ShortUrlController : Controller
    {
        private IDynamoDBContext db;

        public ShortUrlController(IDynamoDBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IList<ShortUrl>> Get()
        {
            return await db.ScanAsync<ShortUrl>(null).GetNextSetAsync();
        }
    }
}
