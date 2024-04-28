namespace shpr2;

public class CorrectnessHandler: Handler
{
    public override void HandleRequest(string login, string password, List<User> users, User? curUser)
    {
        if (login.Length >= 8 
            && !login.Any(char.IsPunctuation))
        {
            if (password.Length >= 8
                && password.Any(char.IsLetter)
                && password.Any(char.IsDigit)
                && password.Any(char.IsPunctuation)
                && password.Any(char.IsLower)
                && password.Any(char.IsUpper))
            {
                Successor?.HandleRequest(login, password, users, curUser);
                return;
            }
            throw new Exception($"Password \"{password}\" is incorrect!");
        }
        throw new Exception($"Login \"{login}\" is incorrect!");
    }
}