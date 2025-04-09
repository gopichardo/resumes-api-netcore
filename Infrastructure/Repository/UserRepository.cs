
using Core.Entity;
using Core.Repository;
using Database;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ResumeDbContext _context;
        public UserRepository(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task InsertUser(User user)
        {
            await _context.User.AddAsync(user);
        }
    }
}