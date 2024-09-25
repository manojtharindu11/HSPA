namespace web_api.Interfaces
{
    public interface IUnitOfWork
    {
        ICityReopository cityReopository { get; }

        IUserRepository userRepository { get; }
        Task<bool> SaveAsync();
    }
}
