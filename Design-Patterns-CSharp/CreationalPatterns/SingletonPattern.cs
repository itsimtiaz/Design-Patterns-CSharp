namespace Design_Patterns_CSharp.CreationalPatterns;

public class SingletonPattern
{

    private static SingletonPattern? _instance;
    private readonly List<int> _numbers;
    private static readonly object _instanceLock = new();

    private SingletonPattern()
    {
        _numbers = new List<int>();
    }

    public void Add(int number) => _numbers.Add(number);

    public IEnumerable<int> GetNumbers() => _numbers.AsReadOnly();

    public static SingletonPattern GetInstance()
    {
        if (_instance is null)
        {
            lock (_instanceLock)
            {
                if (_instance is null)
                    _instance = new();
            }
        }

        return _instance;
    }

}

public class SingletonDemo
{
    public static void Run()
    {
        var instance = SingletonPattern.GetInstance();

        instance.Add(1);
        instance.Add(2);
        instance.Add(3);

        var anotherInstance = SingletonPattern.GetInstance();
        anotherInstance.Add(4);
        anotherInstance.Add(5);

        Console.WriteLine($"numbers are {string.Join(", ", instance.GetNumbers())}");
    }
}
