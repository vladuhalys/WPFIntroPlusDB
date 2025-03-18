namespace Core.Repository.SubjectAndMarksRepository;

public abstract class SubjectAndMarksRepository<T>
{
    public abstract Task<T> GetSubjectAndMarksByUserLogin(string login);
    public abstract Task<bool> AddSubjectAndMarksByUserLogin(string login, string subject, int mark);
}