namespace Design_Patterns_CSharp.CreationalPatterns;

interface IPrototype<T>
{
    T Clone();
}

public class PrototypePattern : IPrototype<PrototypePattern>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public PrototypePattern Clone()
    {
        return new() { Id = Id, Name = Name, Description = Description };
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Description: {Description}";
    }
}

public class PrototypeDemo
{
    public static void Run()
    {
        var obj = new PrototypePattern();
        obj.Id = 1;
        obj.Name = "test";
        obj.Description = "test description.";

        var cloneObj = obj.Clone();

        Console.WriteLine($"Original Object: {obj}");
        Console.WriteLine($"Clone Object: {cloneObj}");
    }
}