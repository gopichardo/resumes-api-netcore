using Core.Entity;
using Core.Repository;

namespace Core.Usecase.Users
{
    public class QueryAllUsersUseCase : IQueryAllUsersUseCase
    {
        private readonly IUserRepository _userRepository;

        public QueryAllUsersUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> QueryAllAsync()
        {

            return _userRepository.GetAllUsersAsync();
        }
    }
}