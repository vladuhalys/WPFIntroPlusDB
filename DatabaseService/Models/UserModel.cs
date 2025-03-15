namespace DatabaseService.Models;

public class UserModel
{
    public int ? id { get; set; }
    public string ? login { get; set; }
    public string ? password { get; set; }
    
    public UserModel(int id, string login, string password)
    {
        this.login = login;
        this.password = password;
        this.id = id;
    }

    public override string ToString()
    {
        return $"Id: {id}, Login: {login}, Password: {password}";
    }
}