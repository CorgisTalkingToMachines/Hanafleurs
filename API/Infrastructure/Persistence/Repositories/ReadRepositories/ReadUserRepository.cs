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

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users
                .Where(user => user.Id == id)
                .SingleAsync();
        }

        public Task<User> FindByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
