using DatabaseService.Abstractions;

namespace DatabaseService.Models;

public class StudentModel: IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Course { get; set; }
    public List<SubjectModel>? Subjects { get; set; }
    
    public StudentModel()
    {
        Subjects = new List<SubjectModel>();
    }
    public StudentModel(int id, string name, string surname, string course)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Course = course;
        Subjects = new List<SubjectModel>();
    }
    public StudentModel(int id, string name, string surname, string course, List<SubjectModel> subjects)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Course = course;
        Subjects = subjects;
    }
    
}