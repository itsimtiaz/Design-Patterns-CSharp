namespace Design_Patterns_CSharp.StructuralPatterns;

interface ITextProcessor
{
    void Process(string input);
}

class PlainTextProcessor : ITextProcessor
{
    public void Process(string input)
    {
        Console.WriteLine($"{input}");
    }
}

class TextEncryption : ITextProcessor
{
    private readonly ITextProcessor textProcessor;

    public TextEncryption(ITextProcessor textProcessor)
    {
        this.textProcessor = textProcessor;
    }
    public void Process(string input)
    {
        Console.WriteLine($"Encrypting text: {input}");
        textProcessor.Process(input);
    }
}

class TextCompression : ITextProcessor
{
    private readonly ITextProcessor textProcessor;

    public TextCompression(ITextProcessor textProcessor)
    {
        this.textProcessor = textProcessor;
    }
    public void Process(string input)
    {
        Console.WriteLine($"Compressing text: {input}");
        textProcessor.Process(input);
    }
}

public class DecoratorPatternDemo
{
    public static void Run()
    {
        var textProcess = new TextCompression(new TextEncryption(new PlainTextProcessor()));

        textProcess.Process("Hello, World!");
    }
}
