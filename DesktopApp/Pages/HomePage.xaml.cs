using System.Windows;
using System.Windows.Controls;
using Core.Repository.SubjectAndMarksRepository;
using DatabaseService.DBProvider;
using DatabaseService.Models;
using DatabaseService.Repository;

namespace DesktopApp.Pages;

public partial class HomePage : UserControl
{
    UserModel _user;
    private DatabaseProvider? _databaseProvider;
    private StudentSubjectMarks? _studentSubjectMarks;
    private SubjectAndMarksRepository<StudentSubjectMarks?>? _subjectAndMarksRepository;

    public HomePage(UserModel user, DatabaseProvider? databaseProvider)
    {
        _user = user;
        _databaseProvider = databaseProvider;
        _subjectAndMarksRepository = new SubjectAndMarksRepositoryImpl(databaseProvider);
        InitializeComponent();
       
    }

    private void OnAddClick(object sender, RoutedEventArgs e)
    {
        
    }
    
    void FillDataGrid(StudentSubjectMarks studentSubjectMarks)
    {
        foreach (var subject in studentSubjectMarks.marks)
        {
            var dataGridCells = new List<DataGridCell>();
            var dataGridCell = new DataGridCell();
            dataGridCell.Content = subject.Key;
            dataGridCells.Add(dataGridCell);
            dataGridCell = new DataGridCell();
            dataGridCell.Content = subject.Value;
            dataGridCells.Add(dataGridCell);
            dgMarkAndSubject.Items.Add(dataGridCells);
        }
        dgMarkAndSubject.Items.Refresh();
    }

    private async void HomePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        _studentSubjectMarks = await _subjectAndMarksRepository?.GetSubjectAndMarksByUserLogin(_user.login);
        if (_studentSubjectMarks != null)
        {
            FillDataGrid(_studentSubjectMarks);
        }
        
    }
}