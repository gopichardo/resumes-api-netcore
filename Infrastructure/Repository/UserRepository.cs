
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
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
           var user = await _context.User.FindAsync(id);

           return user ?? throw new Exception("User not found");
        }
    }
}