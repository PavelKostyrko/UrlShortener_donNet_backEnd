using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data
{
    internal static class ModelBuilderExtension
    {
        internal static void AddData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlDb>()
                .HasData(
                    new UrlDb
                    {
                        Id = 1,
                        LongUrl = "https://metanit.com",
                        ShortUrl = "short.by/YFn1g4",
                        ClicksCount = 0,
                        Created = $"{DateTime.Now:G}",
                    }, 
                    new UrlDb
                    {
                        Id = 2,
                        LongUrl = "https://learn.javascript.ru",
                        ShortUrl = "short.by/IFkSo1",
                        ClicksCount = 0,
                        Created = $"{DateTime.Now:G}",
                    },
                    new UrlDb
                    {
                        Id = 3,
                        LongUrl = "https://rabota.by",
                        ShortUrl = "short.by/GTof2r",
                        ClicksCount = 0,
                        Created = $"{DateTime.Now:G}",
                    },
                    new UrlDb
                    {
                        Id = 4,
                        LongUrl = "https://ru.legacy.reactjs.org",
                        ShortUrl = "short.by/Ar2Tyk",
                        ClicksCount = 0,
                        Created = $"{DateTime.Now:G}",
                    },
                    new UrlDb
                    {
                        Id = 5,
                        LongUrl = "https://hub.docker.com/search?q=mysql&type=image",
                        ShortUrl = "short.by/of4I8g",
                        ClicksCount = 0,
                        Created = $"{DateTime.Now:G}",
                    }
                );
        }
    }
}
