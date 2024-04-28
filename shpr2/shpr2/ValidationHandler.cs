namespace shpr2;

public class ValidationHandler: Handler
{
    public override void HandleRequest(string login, string password, List<User> users, User? curUser)
    {
        if (users.All(user => user.Login != login && user.Password != password))
        {
            throw new Exception($"\"{login}\" is unknown user!");
        }
        
        Successor?.HandleRequest(login, password, users, curUser);
    }
}