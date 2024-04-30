namespace shpr3;

public class TextFileReader : IReader
{
    public string ReadLine(int number)
    {
        Console.WriteLine("Открыт файл");
        
        var streamReader = new StreamReader("Users.txt");
        
        var line = streamReader.ReadLine();
        while (line is not null)
        {
            if (line.Split(';')[0] == number.ToString())
            {
                return line.Split(';')[1];
            }
            line = streamReader.ReadLine();
        }
        streamReader.Close();
        throw new Exception("Unknown user!");
    }

    public void Dispose() { }
}