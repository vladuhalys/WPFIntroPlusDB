using System.Data.SqlClient;
using Dapper;
using DatabaseService.DBCommands;
using DatabaseService.Models;

namespace DatabaseService.DBProvider;

public class DatabaseProvider
{
    private readonly string _connectionString;
        
    public DatabaseProvider(string connectionString)
    {
        _connectionString = connectionString;
    }
        
    public async Task<int> CreateUserAsync(UserModel user)
    {
        await using var connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(DbCommands.InsertUserCommand(user.login, user.password));
    }
        
    public async Task<UserModel?> GetUserAsync(string login)
    {
        await using var connection = new SqlConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<UserModel>(DbCommands.GetUserCommand, new { login });
    }
        
    public async Task InitializeDatabaseAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(DbCommands.CreateDbCommandWithNotExists("School"));
        await connection.ExecuteAsync(DbCommands.CreateTablesCommand());
    }
        
    public async Task ResetDatabaseAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(DbCommands.DropTablesCommand());
        await connection.ExecuteAsync(DbCommands.CreateTablesCommand());
    }
}