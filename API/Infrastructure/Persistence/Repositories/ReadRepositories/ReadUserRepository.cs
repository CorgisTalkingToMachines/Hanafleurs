using API.Domain.Entities;
using API.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence.Repositories.ReadRepositories
{
    public class ReadUserRepository : IReadUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ReadUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _context.Users
                .Where(user => user.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _context.Users
                .Where(user => user.Id == id)
                .SingleAsync();
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            return await _context.Users
                .Where(user => user.Username == username)
                .FirstOrDefaultAsync();
        }
    }
}
