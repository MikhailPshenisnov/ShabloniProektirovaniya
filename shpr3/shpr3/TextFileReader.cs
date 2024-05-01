namespace shpr3;

public class TextFileReader : IReader
{
    // Поиск необходимой записи в файле (перебором) без мгновенного кеширования
    public string ReadLine(int number)
    {
        Console.WriteLine("Открыт файл"); // Сообщение для отслеживания открытия файла
        var streamReader = new StreamReader("Users.txt");
        var line = streamReader.ReadLine();
        while (line is not null) // Перебор всех строк
        {
            if (line.Split(';')[0] == number.ToString())
            {
                return line.Split(';')[1]; // Возвращение нужного значения
            }

            line = streamReader.ReadLine();
        }

        streamReader.Close();
        throw new Exception("Unknown user!"); // Ошибка если строка не найдена
    }

    // Поиск необходимой записи в файле (перебором) с мгновенным кешированием
    public string ReadLineWithCash(int number, ProxyReader proxyReader)
        // В функцию передается ссылка на словарь с кешированными данными, чтобы записывать данные сразу при переборе
    {
        Console.WriteLine("Открыт файл"); // Сообщение для отслеживания открытия файла

        var streamReader = new StreamReader("Users.txt");
        var line = streamReader.ReadLine();
        while (line is not null) // Перебор всех строк
        {
            // Если в словаре еще нет записи для считанной строки, то для нее создается запись
            if (!proxyReader.Users.ContainsKey(line.Split(';')[0]))
                proxyReader.Users.Add(line.Split(';')[0], line.Split(';')[1]);

            if (line.Split(';')[0] == number.ToString())
            {
                return line.Split(';')[1]; // Возвращение нужного значения
            }

            line = streamReader.ReadLine();
        }

        streamReader.Close();
        throw new Exception("Unknown user!"); // Ошибка если строка не найдена
    }

    public void Dispose()
    {
    }
}