using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models.Commands
{
    public class AddShortUrl
    {
        [Required(AllowEmptyStrings = false)]
        [Url]
        public string Url { get; set; }
    }
}
