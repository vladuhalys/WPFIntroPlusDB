namespace Core.Repository.AuthRepository;

public abstract class AuthRepository
{
    public abstract Task<bool> RegisterAsync(string email, string password);
    public abstract Task<bool> LoginAsync(string email, string password);
}