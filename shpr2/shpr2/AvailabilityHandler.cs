namespace shpr2;

public class AvailabilityHandler : Handler
{
    public override void HandleRequest(string login, string password, List<User> users, User? curUser)
    {
        if (users.Any(t => t.Login == login))
        {
            throw new Exception($"Login \"{login}\" is already used!");
        }
        
        Successor?.HandleRequest(login, password, users, curUser);
    }
}