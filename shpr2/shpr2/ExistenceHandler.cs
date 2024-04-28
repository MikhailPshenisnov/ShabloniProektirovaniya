namespace shpr2;

public class ExistenceHandler: Handler
{
    public override void HandleRequest(string login, string password, List<User> users, User? curUser)
    {
        if (curUser != null)
        {
            throw new Exception($"First you need to log out of current account!");;
        }
        Successor?.HandleRequest(login, password, users, curUser);
    }
}