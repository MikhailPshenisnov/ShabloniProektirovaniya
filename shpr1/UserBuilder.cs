namespace shpr1;

public abstract class UserBuilder
{
    public User User { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public delegate bool CheckMethod(string username);
    public CheckMethod CheckUsernameMethod { get; set; }
    public CheckMethod CheckPasswordMethod { get; set; }

    protected static int idSeed = 0;
    
    public UserBuilder(string tmpUsername, string tmpPassword,
        CheckMethod? tmpCheckUsernameMethod = null,
        CheckMethod? tmpCheckPasswordMethod = null)
    {
        Username = tmpUsername;
        Password = tmpPassword;
        CheckUsernameMethod = tmpCheckUsernameMethod ?? delegate(string username) { return true; };
        CheckPasswordMethod = tmpCheckPasswordMethod ?? delegate(string username) { return true; };
    }

    public void CreateUser()
    {
        User = new User();
    }
    
    public abstract void GenerateId();
    public abstract void CheckUsername();
    public abstract void CheckPassword();
    public abstract void SetRole();
}