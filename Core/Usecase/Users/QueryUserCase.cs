
using Core.Entity;
using Core.Repository;

namespace Core.Usecase.Users
{
    public class QueryUserCase : IQueryUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public QueryUserCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> QueryAsync(Guid id)
        {
            return await _userRepository.GetUser(id);
        }
    }
}