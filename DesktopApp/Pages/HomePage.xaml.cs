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
    private SubjectAndMarksRepository<IEnumerable<dynamic>>? _subjectAndMarksRepository;

    public HomePage(UserModel user, DatabaseProvider? databaseProvider)
    {
        _user = user;
        _databaseProvider = databaseProvider;
        _subjectAndMarksRepository = new SubjectAndMarksRepositoryImpl(databaseProvider);
        InitializeComponent();
       
    }

    private async void OnAddClick(object sender, RoutedEventArgs e)
    {
        try
        {
            await _subjectAndMarksRepository?.AddSubjectAndMarksByUserLogin(_user.login, tbSubject.Text, int.Parse(tbMark.Text));
            await RefreshDataGrid();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "System Exeption", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    async Task RefreshDataGrid()
    {
        var items =  await _subjectAndMarksRepository?.GetSubjectAndMarksByUserLogin(_user.login);
        dgMarkAndSubject.ItemsSource = items;
        dgMarkAndSubject.UpdateLayout();
        
    }

    private async void HomePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await RefreshDataGrid();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "System Exeption", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}