using Core.Repository.SubjectAndMarksRepository;
using DatabaseService.DBProvider;
using DatabaseService.Models;

namespace DatabaseService.Repository;

public class SubjectAndMarksRepositoryImpl : SubjectAndMarksRepository<IEnumerable<dynamic>?>
{
    private readonly DatabaseProvider _databaseProvider;
    public SubjectAndMarksRepositoryImpl(DatabaseProvider databaseProvider)
    {
        _databaseProvider = databaseProvider;
    }
    
    public override async Task<IEnumerable<dynamic>?> GetSubjectAndMarksByUserLogin(string login)
    {
        var result = await _databaseProvider.GetSubjectAndMarksByUserLogin(login);
        return result;
    }

    public override async Task<bool> AddSubjectAndMarksByUserLogin(string login, string subject, int mark)
    {
        var result = await _databaseProvider.InsertMarkAndSubjectByUserLogin(login, subject, mark);
        return result > 0;
    }
}