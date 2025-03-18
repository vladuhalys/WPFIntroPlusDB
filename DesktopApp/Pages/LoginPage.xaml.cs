using System.Windows;
using System.Windows.Controls;
using Core.Repository.AuthRepository;
using DatabaseService.DBProvider;
using DatabaseService.Models;
using DatabaseService.Repository;

namespace DesktopApp.Pages;

public partial class LoginPage : UserControl
{
    private AuthRepository<UserModel?>? _authRepository;
    private DatabaseProvider? _databaseProvider;
    public LoginPage(DatabaseProvider? databaseProvider)
    {
        InitializeComponent();
        _databaseProvider = databaseProvider;
        if (databaseProvider != null) _authRepository = new AuthRepositoryImpl(databaseProvider);
    }

    private async void OnLoginButtonClick(object sender, RoutedEventArgs e)
    {
        var login = LoginTextBox.Text;
        var password = PasswordBox.Password;
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Login and password cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        var user = await _authRepository?.LoginAsync(login, password)!;
        if (user == null)
        {
            MessageBox.Show("Login failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            var result = MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            if(result == MessageBoxResult.OK)
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.MainWindowFrame.Navigate(new HomePage(user, _databaseProvider));
            }
        }
    }
}