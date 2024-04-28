namespace shpr1;

public class CommonUserBuilder : UserBuilder
{
    public CommonUserBuilder(string tmpUsername, string tmpPassword,
        CheckMethod? tmpCheckUsernameMethod = null,
        CheckMethod? tmpCheckPasswordMethod = null) :
        base(tmpUsername, tmpPassword, tmpCheckUsernameMethod, tmpCheckPasswordMethod)
    {
    }

    public override void GenerateId()
    {
        User.Id = idSeed++;
    }

    public override void CheckUsername()
    {
        if (CheckUsernameMethod(Username))
        {
            User.Username = Username;
        }
        else
        {
            throw new Exception($"Incorrect username \"{Username}\"!");
        }
    }

    public override void CheckPassword()
    {
        if (CheckPasswordMethod(Password))
        {
            User.Password = Password;
        }
        else
        {
            throw new Exception($"Incorrect password \"{Password}\"!");
        }
    }

    public override void SetRole()
    {
        User.Role = "Common user";
    }
}