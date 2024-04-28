using shpr1;

try
{
    var creator = new UserCreator();

    var commonUserBuilderbuilder = new CommonUserBuilder("Oleg Petrov", "12345Aa!",
        username =>
        (
            username.Length >= 8
            && !username.Any(char.IsPunctuation)
        ),
        password =>
        (
            password.Length >= 8
        ));

    var adminUserBuilder = new AdminUserBuilder("Ivan Ivanov", "12345678Abc;",
        username =>
        (
            username.Length >= 8
            && !username.Any(char.IsPunctuation)
        ),
        password =>
        (
            password.Length >= 8
            && password.Any(char.IsLetter)
            && password.Any(char.IsDigit)
            && password.Any(char.IsPunctuation)
            && password.Any(char.IsLower)
            && password.Any(char.IsUpper)
        ));

    var commonUser = creator.Build(commonUserBuilderbuilder);
    var adminUser = creator.Build(adminUserBuilder);

    Console.WriteLine($"{commonUser.Id} :: {commonUser.Username} ({commonUser.Role}) password=\"{commonUser.Password}\"");
    Console.WriteLine($"{adminUser.Id} :: {adminUser.Username} ({adminUser.Role}) password=\"{adminUser.Password}\"");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}