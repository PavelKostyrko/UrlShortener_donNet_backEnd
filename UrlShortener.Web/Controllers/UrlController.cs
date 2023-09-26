using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UrlShortener.Logic.Models;
using UrlShortener.Logic.Services;

namespace UrlShortener.Web.Controllers
{
    [ApiController]
    [Route("api/url")]

    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public async Task<ICollection<UrlDto>> GetAllAsync()
        {
            return await _urlService.GetAllAsync();
        }

        [HttpGet("{urlId}")]
        public async Task<UrlDto> GetByIdAsync(int? urlId)
        {
            if (urlId == null)
                throw new ValidationException("Object Id can't be null.");

            return await _urlService.GetByIdAsync(urlId) ?? throw new ValidationException("Object with this Id don`t exist.");
        }

        [HttpPost("create")]
        public async Task<UrlDto> CreateAsync([FromBody] UrlDto urlDto)
        {
            return await _urlService.CreateAsync(urlDto) ?? throw new ValidationException("Object has not created");
        }

        [HttpPut("update")]
        public async Task<UrlDto> UpdateAsync([FromBody] UrlDto urlDto)
        {
            return await _urlService.UpdateAsync(urlDto);
        }

        [HttpDelete("{urlId}")]
        public async Task DeleteAsync(int? urlId)
        {
            if (urlId == null)
                throw new ValidationException("Object Id can't be null.");

            await _urlService.DeleteAsync(urlId);
        }

        [HttpGet("short.by/{shortUrl}")]
        public async Task<string> RedirectAsync(string shortUrl)
        {
            if (shortUrl == null)
                throw new ValidationException("Short URL can`t be null.");

            return await _urlService.RedirectAsync(shortUrl) ?? throw new ValidationException("This short URL don`t exist.");
        }
    }
}