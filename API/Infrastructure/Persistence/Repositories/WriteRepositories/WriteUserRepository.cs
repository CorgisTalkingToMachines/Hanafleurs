using API.Domain.Entities;
using API.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence.Repositories.WriteRepositories
{
    public class WriteUserRepository : IWriteUserRepository
    {
        private readonly ApplicationDbContext _context;

        public WriteUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
