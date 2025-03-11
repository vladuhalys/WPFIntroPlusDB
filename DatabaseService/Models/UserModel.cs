namespace DatabaseService.Models;

public class UserModel
{
    public string ? login { get; set; }
    public string ? password { get; set; }
    
    public UserModel(string login, string password)
    {
        this.login = login;
        this.password = password;
    }

    public override string ToString()
    {
        return $"Login: {login}, Password: {password}";
    }
}