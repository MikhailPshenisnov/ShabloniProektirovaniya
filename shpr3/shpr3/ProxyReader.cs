namespace shpr3;

public class ProxyReader: IReader
{
    private TextFileReader? _textFileReader;
    private Dictionary<string, string> _users;

    public ProxyReader()
    {
        _users = new Dictionary<string, string>();
    }
    
    public string ReadLine(int number)
    {
        string? result;
        if (_users.ContainsKey(number.ToString()))
        {
            result = _users[number.ToString()];
        }
        else
        {
            result = null;
        }

        if (result is not null) return result;
        
        _textFileReader ??= new TextFileReader();
        result = _textFileReader.ReadLine(number);
        _users.Add(number.ToString(), result);
        return result;
    }

    public void Dispose()
    {
        _textFileReader?.Dispose();
    }
}