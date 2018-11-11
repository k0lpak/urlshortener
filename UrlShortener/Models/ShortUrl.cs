using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.Models
{
    [DynamoDBTable("ShortUrl")]
    public class ShortUrl
    {
        [DynamoDBHashKey]
        public string ShortKey { get; set; }

        public string FullUrl { get; set; }
    }
}
