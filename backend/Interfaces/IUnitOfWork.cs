namespace web_api.Interfaces
{
    public interface IUnitOfWork
    {
        ICityReopository cityReopository { get; }
        Task<bool> SaveAsync();
    }
}
