using DatabaseService.Abstractions;

namespace DatabaseService.Models;

public class MarkModel : IModel
{
    public int Id { get; set; }
    public List<int>? Marks { get; set; }
    public int ? Average { get; set; }
    
    public MarkModel()
    {
        Marks = new List<int>();
    }
    public MarkModel(int id, List<int> marks)
    {
        Id = id;
        Marks = marks;
    }
    public MarkModel(int id, List<int> marks, int average)
    {
        Id = id;
        Marks = marks;
        Average = average;
    }
}