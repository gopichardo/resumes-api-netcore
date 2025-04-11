
using Core.Entity;
using Core.Repository;
using Database;
using Microsoft.EntityFrameworkCore;

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
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid user ID", nameof(id));
            }

            var user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();
        }
    }
}