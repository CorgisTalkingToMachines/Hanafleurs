using API.Domain.Entities;
using API.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence.Repositories.WriteRepositories
{
    public class WriteUserRepository : IWriteUserRepository, IReadUserRepository
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

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users
                .Where(user => user.Id == id)
                .SingleAsync();
        }

        public async Task SaveAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
