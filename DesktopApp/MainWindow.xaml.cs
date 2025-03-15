using System.Data.SqlClient;
using System.Windows;
using DatabaseService.DBProvider;

namespace DesktopApp;

public partial class MainWindow : Window
{
    private DatabaseProvider _provider;
    public MainWindow()
    {
        InitializeComponent();
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;";
        _provider = new DatabaseProvider(connectionString);
    }

    [Obsolete("Obsolete")]
    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await _provider.InitializeDatabaseAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            await _provider.ResetDatabaseAsync();
            await _provider.InitializeDatabaseAsync();
        }
        finally
        {
            MainWindowFrame.Navigate(new Pages.LoginPage(_provider));
        }
    }
}

