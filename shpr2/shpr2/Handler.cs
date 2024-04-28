namespace shpr2;

public abstract class Handler
{
    public Handler? Successor { get; set; }
    public abstract void HandleRequest(string login, string password, List<User> users, User? curUser);
}