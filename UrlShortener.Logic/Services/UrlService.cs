using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UrlShortener.Data;
using UrlShortener.Logic.AuxiliaryСlasses;
using UrlShortener.Logic.Builders;
using UrlShortener.Logic.Models;

namespace UrlShortener.Logic.Services
{
    public class UrlService : BaseService, IUrlService
    {
        public UrlService(UrlDbContext context) : base(context)
        {

        }

        /// <summary> Gets all urls from DB. </summary>
        /// <returns> Returns a collection of urls. </returns>
        public async Task<ICollection<UrlDto>> GetAllAsync()
        {
            var urlDbs = await _context.Urls.ToListAsync().ConfigureAwait(false);

            return UrlBuilder.Build(urlDbs);
        }

        /// <summary> Gets the url from DB by Id. </summary>
        /// <param name="urlId"></param>
        /// <returns> Returns the object with Id: <paramref name="urlId"/>. </returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<UrlDto> GetByIdAsync(int? urlId)
        {
            if (urlId == null)
            {
                throw new ValidationException("Object Id can't be null.");
            }

            var urlDb = await _context.Urls.SingleOrDefaultAsync(o => o.Id == urlId).ConfigureAwait(false);

            return UrlBuilder.Build(urlDb);
        }

        /// <summary> Creates new url. </summary>
        /// <param name="urlDto"></param>
        /// <returns> Returns an object with long and short links. </returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ValidationException"></exception>
        public async Task<UrlDto> CreateAsync(UrlDto urlDto)
        {
            if (urlDto.Id == null 
                && !string.IsNullOrEmpty(urlDto.LongUrl)
                && urlDto.LongUrl.Length > 5
                && (urlDto.LongUrl.StartsWith("https://") 
                    || urlDto.LongUrl.StartsWith("http://") 
                    || urlDto.LongUrl.StartsWith("www.")))
            {
                urlDto.ShortUrl = Shortener.CreateShortLink();
                urlDto.Created = $"{DateTime.Now:G}";

                await _context.Urls.AddAsync(UrlBuilder.Build(urlDto)).ConfigureAwait(false);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    var urlDtoObj = await _context.Urls
                        .SingleOrDefaultAsync(o => o.LongUrl == urlDto.LongUrl && o.ShortUrl == urlDto.ShortUrl);
                    return UrlBuilder.Build(urlDtoObj);
                }
                catch
                {
                    throw new Exception("Object has not been created.");
                }
            }

            throw new ValidationException("The link you are trying to shorten is invalid");
        }

        /// <summary> Updates the url in DB. </summary>
        /// <param name="urlDto"></param>
        /// <returns> Returns the object with long and short links. </returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ValidationException"></exception>
        public async Task<UrlDto> UpdateAsync(UrlDto urlDto)
        {
            if (urlDto.Id != null
                && !string.IsNullOrEmpty(urlDto.LongUrl)
                && urlDto.LongUrl.Length > 5
                && (urlDto.LongUrl.StartsWith("https://")
                    || urlDto.LongUrl.StartsWith("http://")
                    || urlDto.LongUrl.StartsWith("www.")))
            {
                var urlDb = await _context.Urls.SingleOrDefaultAsync(_ => _.Id == urlDto.Id).ConfigureAwait(false);

                if (urlDb != null)
                {
                    urlDb.LongUrl = urlDto.LongUrl;
                    urlDb.ShortUrl = Shortener.CreateShortLink();
                    urlDb.ClicksCount = 0;
                    urlDb.Created = $"{DateTime.Now:G}";

                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                        return UrlBuilder.Build(urlDb);
                    }
                    catch
                    {
                        throw new Exception("Object has not been updated.");
                    }
                }
                else
                {
                    throw new ValidationException("There is not object, that you are trying to update.");
                }
            }

            throw new ValidationException("The link you are trying to shorten is invalid");
        }

        /// <summary> Deletes the url from DB. </summary>
        /// <param name="urlId"></param>
        /// <returns> Returns operation status code. </returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int? urlId)
        {
            if (urlId == null)
            {
                throw new ValidationException("Invalid object Id.");
            }

            var urlDb = await _context.Urls.SingleOrDefaultAsync(_ => _.Id == urlId).ConfigureAwait(false);

            if (urlDb != null)
            {
                _context.Urls.Remove(urlDb);

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch
                {
                    throw new Exception("Object has not been deleted.");
                }
            }
            else
            {
                throw new ValidationException("There is not object, that you are trying to delete."); 
            }
        }

        /// <summary> Redirects from the shortlink to the long link. </summary>
        /// <param name="shortUrl"></param>
        /// <returns> Returns the long url. </returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<string> RedirectAsync(string shortUrl)
        {
            if (!string.IsNullOrEmpty(shortUrl))
            {
                var urlDb = await _context.Urls
                    .SingleOrDefaultAsync(_ => _.ShortUrl == $"short.by/{shortUrl}").ConfigureAwait(false);

                if (urlDb != null)
                {
                    urlDb.ClicksCount++;
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    return urlDb.LongUrl;
                }
                else
                {
                    throw new ValidationException("There is not object with this shortlink.");
                }
            }

            throw new ValidationException("The shortlink can`t be empty.");
        }
    }
}