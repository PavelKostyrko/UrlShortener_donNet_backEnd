using UrlShortener.Data.Models;
using UrlShortener.Logic.Models;

namespace UrlShortener.Logic.Builders
{
    public class UrlBuilder
    {
        public static UrlDb Build(UrlDto obj) 
        { 
            return obj != null
                ? new UrlDb() 
                {
                    Id = obj.Id,
                    LongUrl = obj.LongUrl,
                    ShortUrl = obj.ShortUrl,
                    ClicksCount = obj.ClicksCount,
                    Created = obj.Created
                }
                : null; 
        }

        public static ICollection<UrlDb> Build(ICollection<UrlDto> col)
        {
            return col?.Select(o => Build(o)).ToList();
        }

        public static UrlDto Build(UrlDb obj)
        {
            return obj != null
                ? new UrlDto()
                {
                    Id = obj.Id,
                    LongUrl = obj.LongUrl,
                    ShortUrl = obj.ShortUrl,
                    ClicksCount = obj.ClicksCount,
                    Created = obj.Created
                }
                : null;
        }

        public static ICollection<UrlDto> Build(ICollection<UrlDb>  col)
        {
            return col?.Select(o => Build(o)).ToList();
        }
    }
}
