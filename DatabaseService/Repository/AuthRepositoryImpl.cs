using Core.Repository.AuthRepository;
using DatabaseService.DBProvider;
using DatabaseService.Models;

namespace DatabaseService.Repository;

public class AuthRepositoryImpl : AuthRepository<UserModel?>
{
    private readonly DatabaseProvider _databaseProvider;
    
    public AuthRepositoryImpl(DatabaseProvider databaseProvider)
    {
        _databaseProvider = databaseProvider;
    }
    [Obsolete("Obsolete")]
    public override async Task<bool> RegisterAsync(string email, string password)
    {
        UserModel user = new UserModel(0, email, password);
        var resultResponse = await _databaseProvider.CreateUserAsync(user);
        return resultResponse > 0;
    }       
    
    [Obsolete("Obsolete")]
    public override async Task<UserModel?> LoginAsync(string email, string password)
    {
        return await _databaseProvider.GetUserAsync(email);
    }
}