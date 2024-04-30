namespace shpr3;

public interface IReader : IDisposable
{
    public string ReadLine(int number);
}