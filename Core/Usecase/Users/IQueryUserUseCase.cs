using Core.Entity;

namespace Core.Usecase.Users
{
    public interface IQueryUserUseCase
    {
        Task<User> QueryAsync(Guid id);
    }
}