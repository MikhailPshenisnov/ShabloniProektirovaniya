namespace shpr2;

public class UserManager
{
    private List<User> Users { get; set; } = new();
    public User? CurrentUser { get; set; } = null;

    public void Registration(string login, string password)
    {
        try
        {
            var h1 = new ExistenceHandler();
            var h2 = new CorrectnessHandler();
            var h3 = new AvailabilityHandler();
            h1.Successor = h2;
            h2.Successor = h3;
            
            h1.HandleRequest(login, password, Users, CurrentUser);
            Users.Add(new User(login, password));
            CurrentUser = new User(login, password);
            Console.WriteLine($"User \"{login}\" has been successfully registered and logged into his account");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Authorisation(string login, string password)
    {
        try
        {
            var h1 = new ExistenceHandler();
            var h2 = new CorrectnessHandler();
            var h3 = new ValidationHandler();
            h1.Successor = h2;
            h2.Successor = h3;
            
            h1.HandleRequest(login, password, Users, CurrentUser);
            CurrentUser = new User(login, password);
            Console.WriteLine($"User \"{login}\" successfully logged into his account");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Logout()
    {
        try
        {
            if (CurrentUser is null)
            {
                throw new Exception("You are not logged into any account!");
            }

            CurrentUser = null;
            Console.WriteLine("You have successfully logged out of your account");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}