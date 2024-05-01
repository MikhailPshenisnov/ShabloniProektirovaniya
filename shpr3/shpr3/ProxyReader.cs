namespace shpr3;

public class ProxyReader : IReader
{
    private TextFileReader? _textFileReader; // Считыватель данных из файла
    public Dictionary<string, string> Users { get; set; } // Словарь для кеша

    public ProxyReader()
    {
        Users = new Dictionary<string, string>();
    }

    public string ReadLine(int number)
    {
        // Считывание данных из кеша, если они есть
        var result = Users.ContainsKey(number.ToString()) ? Users[number.ToString()] : null; 
        if (result is not null) return result;

        // Если данных не нашлось, то следует обращение к файлу
        _textFileReader ??= new TextFileReader();
        
        // Чтение из файла без мгновенного кеширования и кеширование только результата
        result = _textFileReader.ReadLine(number);
        Users.Add(number.ToString(), result);
        
        // Чтение из файла с мгновенным кешированием
        // result = _textFileReader.ReadLineWithCash(number, this);

        return result; // Возвращение нужного значения
    }

    public void Dispose()
    {
        _textFileReader?.Dispose();
    }
}