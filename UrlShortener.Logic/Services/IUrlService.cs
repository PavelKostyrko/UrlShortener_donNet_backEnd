using UrlShortener.Logic.Models;

namespace UrlShortener.Logic.Services
{
    public interface IUrlService
    {
        Task<ICollection<UrlDto>> GetAllAsync();
        Task<UrlDto> GetByIdAsync(int? longUrlId);
        Task<UrlDto> CreateAsync(UrlDto longUrlDto);
        Task<UrlDto> UpdateAsync(UrlDto longUrlDto);
        Task DeleteAsync(int? longUrlId);
        Task<string> RedirectAsync(string shortUrl);
    }
}
