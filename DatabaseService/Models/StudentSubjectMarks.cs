using DatabaseService.Abstractions;

namespace DatabaseService.Models;

public class StudentSubjectMarks : IModel
{
    public StudentModel student { get; set; }
    public Dictionary<SubjectModel, List<MarkModel>> marks { get; set; }
    
    public StudentSubjectMarks()
    {
        student = new StudentModel();
        marks = new Dictionary<SubjectModel, List<MarkModel>>();
    }
    public StudentSubjectMarks(StudentModel student, Dictionary<SubjectModel, List<MarkModel>> marks)
    {
        this.student = student;
        this.marks = marks;
    }
}