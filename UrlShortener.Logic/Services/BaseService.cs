using UrlShortener.Data;

namespace UrlShortener.Logic.Services
{
    public class BaseService : IDisposable
    {
        protected readonly UrlDbContext _context;
        private bool _isDisposed = false;
        protected BaseService(UrlDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;

            _context?.Dispose();
            _isDisposed = true;

            if (flag) GC.SuppressFinalize(this);
        }

        ~BaseService()
        {
            Dispose(false);
        }
    }
}
