namespace shpr1;

public class UserCreator
{
    public User Build(UserBuilder builder)
    {
        builder.CreateUser();
        builder.GenerateId();
        builder.CheckUsername();
        builder.CheckPassword();
        builder.SetRole();

        return builder.User ?? throw new Exception("Something went wrong!");
    }
}