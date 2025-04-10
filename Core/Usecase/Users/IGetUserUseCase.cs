using Core.Entity;

namespace Core.Usecase.Users
{
    public interface IGetUserUseCase
    {
        Task<User> QueryAsync(Guid id);
    }
}