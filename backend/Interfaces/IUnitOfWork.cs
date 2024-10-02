namespace web_api.Interfaces
{
    public interface IUnitOfWork
    {
        ICityReopository cityReopository { get; }

        IUserRepository userRepository { get; }

        IPropertyRepository propertyRepository { get; }

        IPropertyTypeRepository propertyTypeRepository { get; }
        Task<bool> SaveAsync();
    }
}
