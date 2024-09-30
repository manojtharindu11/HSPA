namespace web_api.Interfaces
{
    public interface IUnitOfWork
    {
        ICityReopository cityReopository { get; }

        IUserRepository userRepository { get; }

        IPropertyRepository propertyRepository { get; }
        Task<bool> SaveAsync();
    }
}
