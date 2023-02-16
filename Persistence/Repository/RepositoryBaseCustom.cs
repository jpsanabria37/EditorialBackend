
using Persistence.Contexts;


namespace Persistence.Repository
{
    public abstract class RepositoryBaseCustom
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBaseCustom(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
