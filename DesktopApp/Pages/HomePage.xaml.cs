using System.Windows.Controls;
using DatabaseService.Models;

namespace DesktopApp.Pages;

public partial class HomePage : UserControl
{
    UserModel _user;
    public HomePage(UserModel user)
    {
        _user = user;
        InitializeComponent();
        WelcomeText.Text = $"Welcome, {_user.login}";
    }
}