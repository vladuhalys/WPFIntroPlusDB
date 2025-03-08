using System.Data.SqlClient;
using Dapper;
using DatabaseService.DBCommands;

namespace DatabaseService.DBProvider;

public class DatabaseProvider(string connectionString)
{
    [Obsolete("Obsolete")]
    public async Task InitializeDatabaseAsync()
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(DbCommands.CreateDbCommandWithNotExists("School"));
        await connection.ExecuteAsync(DbCommands.CreateTablesCommand());
    }
    
    [Obsolete("Obsolete")]
    public async Task ResetDatabaseAsync()
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(DbCommands.DropTablesCommand());
        await connection.ExecuteAsync(DbCommands.CreateTablesCommand());
    }
}