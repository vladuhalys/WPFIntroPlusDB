namespace Core.Repository.AuthRepository;

public abstract class AuthRepository<T>
{
    public abstract Task<bool> RegisterAsync(string email, string password);
    public abstract Task<T> LoginAsync(string email, string password);
}